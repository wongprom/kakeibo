import { defineConnection } from "@cursor/bdk/connections";

export default defineConnection({
  agent: "coder",
  description:
    "Delegate Kakeibo backend implementation (C#, EF, GraphQL, migrations, tests) to the coder specialist.",
});
