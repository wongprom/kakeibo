import { defineConnection } from "@cursor/bdk/connections";

export default defineConnection({
  agent: "deployer",
  description:
    "Ask the deployer to merge a PR (only after green checks incl. Vercel; main needs stated user approval) and to check the Vercel deployment of a commit/branch in wongprom/test-next-13 or wongprom/kakeibo.",
});
