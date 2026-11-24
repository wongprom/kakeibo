import type { HostMcpRegistry, HostMcpToolInfo } from "@cursor/bdk";

/** Read-only Figma tools the designer may use. Anything else is refused. */
export const READ_ONLY_FIGMA_TOOLS = [
  "whoami",
  "create_session",
  "get_design_context",
  "get_screenshot",
  "get_metadata",
  "get_variable_defs",
  "get_code_connect_map",
  "get_libraries",
  "search_design_system",
  "get_comments",
  "get_figjam",
] as const;

export type ReadOnlyFigmaTool = (typeof READ_ONLY_FIGMA_TOOLS)[number];

/** Host connections tried in order: the Cursor account first, then the desktop app. */
export const FIGMA_CONNECTIONS = ["figma", "figma-desktop"] as const;

export interface ResolvedFigmaTool {
  tool: ReadOnlyFigmaTool;
  connection: string;
  backendName: string;
  info: HostMcpToolInfo;
}

export interface FigmaCatalog {
  resolved: ResolvedFigmaTool[];
  missing: ReadOnlyFigmaTool[];
  errors: { connection: string; message: string }[];
  sampleNames: Record<string, string[]>;
}

function describe(error: unknown): string {
  return error instanceof Error ? error.message : String(error);
}

/**
 * The account bridge may expose tools as `get_design_context` or prefixed with
 * the connector identifier (for example `user-figma-get_design_context`), with
 * illegal characters turned into `_`. Match the bare name exactly, or a name
 * that mentions "figma" and ends with the tool, so other connectors' tools of
 * the same name are never picked.
 */
function pickTool(
  tool: ReadOnlyFigmaTool,
  listed: HostMcpToolInfo[],
): HostMcpToolInfo | undefined {
  const exact = listed.filter((info) => info.name === tool);
  if (exact.length === 1) return exact[0];
  const prefixed = listed.filter(
    (info) =>
      /figma/i.test(info.name) && new RegExp(`[-_.:/]${tool}$`).test(info.name),
  );
  return prefixed.length === 1 ? prefixed[0] : undefined;
}

export async function loadFigmaCatalog(
  host: HostMcpRegistry,
): Promise<FigmaCatalog> {
  const resolved: ResolvedFigmaTool[] = [];
  const errors: FigmaCatalog["errors"] = [];
  const sampleNames: Record<string, string[]> = {};
  const known = new Set(host.names());

  for (const connection of FIGMA_CONNECTIONS) {
    if (!known.has(connection)) {
      errors.push({ connection, message: "connection not configured" });
      continue;
    }
    let listed: HostMcpToolInfo[];
    try {
      listed = await host.listTools(connection);
    } catch (error) {
      errors.push({ connection, message: describe(error) });
      continue;
    }
    sampleNames[connection] = listed.slice(0, 40).map((info) => info.name);
    for (const tool of READ_ONLY_FIGMA_TOOLS) {
      if (resolved.some((entry) => entry.tool === tool)) continue;
      const info = pickTool(tool, listed);
      if (info) {
        resolved.push({ tool, connection, backendName: info.name, info });
      }
    }
  }

  const missing = READ_ONLY_FIGMA_TOOLS.filter(
    (tool) => !resolved.some((entry) => entry.tool === tool),
  );
  return { resolved, missing, errors, sampleNames };
}
