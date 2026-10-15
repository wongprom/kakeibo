import { defineEval, includes } from "@cursor/bdk/evals";

export default defineEval({
  tags: ["smoke"],
  cases: [
    {
      id: "routes-architecture",
      description:
        "Lead delegates architecture work and returns a design-shaped answer.",
      async test(t) {
        await t.send(
          "How should we model recurring expense categories for budgets in the database and GraphQL API?",
        );
        t.succeeded();
        // Peer MCP tools are attached on the architect connection; assert
        // the reply looks like a design plan (entities / migrations / API).
        t.check(
          t.reply,
          includes(/architect|entity|entities|migration|graphql|schema|relation/i),
        );
      },
    },
  ],
});
