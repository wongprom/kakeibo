import { dirname, join } from "node:path";
import { fileURLToPath } from "node:url";
import { defineAgent } from "@cursor/bdk";

// Repo root (…/kakeibo). Backend checks run here; the frontend checkout is a
// sibling `../test-next-13` (or KAKEIBO_FRONTEND_ROOT) and is reached by path.
const repoRoot = join(dirname(fileURLToPath(import.meta.url)), "../../..");

export default defineAgent({
  model: {
    id: "grok-4.5",
    params: [
      { id: "effort", value: "high" },
      { id: "fast", value: "true" },
    ],
  },
  local: {
    workspaceDir: repoRoot,
  },
});
