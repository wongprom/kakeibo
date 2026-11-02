import { dirname, join } from "node:path";
import { fileURLToPath } from "node:url";
import { defineAgent } from "@cursor/bdk";

// Backend monorepo root (…/kakeibo). Frontend lives in a sibling clone
// `../test-next-13`, or override with KAKEIBO_FRONTEND_ROOT.
const repoRoot = join(dirname(fileURLToPath(import.meta.url)), "../../..");
const frontendRoot =
  process.env.KAKEIBO_FRONTEND_ROOT ?? join(repoRoot, "..", "test-next-13");

export default defineAgent({
  model: {
    id: "grok-4.5",
    params: [
      { id: "effort", value: "high" },
      { id: "fast", value: "true" },
    ],
  },
  local: {
    workspaceDir: frontendRoot,
  },
});
