import { defineConnection } from "@cursor/bdk/connections";

export default defineConnection({
  agent: "tester",
  description:
    "Ask the tester to verify a branch or PR in wongprom/kakeibo or wongprom/test-next-13: lint, typecheck, build, tests, and a diff review against product locks and acceptance criteria. Reports pass/fail with findings; adds test files only when asked; never merges.",
});
