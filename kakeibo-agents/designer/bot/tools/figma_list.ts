import { defineTool } from "@cursor/bdk/tools";
import { loadFigmaCatalog } from "../lib/figma";

export default defineTool({
  description:
    "List the read-only Figma tools available right now (with their input schemas) and why any are missing. Call this first when you need Figma; if nothing is available, tell lead what the result says.",
  effect: "read",
  async execute(_input, ctx) {
    const catalog = await loadFigmaCatalog(ctx.host.mcp);
    return {
      available: catalog.resolved.map((entry) => ({
        tool: entry.tool,
        via: entry.connection,
        description: entry.info.description ?? "",
        inputSchema: entry.info.inputSchema ?? {},
      })),
      missing: catalog.missing,
      errors: catalog.errors,
      ...(catalog.resolved.length === 0
        ? { toolNamesSeen: catalog.sampleNames }
        : {}),
    };
  },
});
