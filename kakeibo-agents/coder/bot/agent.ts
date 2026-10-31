import { dirname, join } from "node:path";
import { fileURLToPath } from "node:url";
import { defineAgent } from "@cursor/bdk";

// Repo root (…/kakeibo): sessions share the real checkout so edits land
// in test-next-13-backend-cSharp-Project, not a disposable cache workspace.
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
