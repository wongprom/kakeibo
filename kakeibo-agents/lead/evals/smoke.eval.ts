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
          "How should we model recurring expense categories for budgets in the database and GraphQL API? Design only — do not implement yet.",
        );
        t.succeeded();
        t.check(
          t.reply,
          includes(/architect|entity|entities|migration|graphql|schema|relation/i),
        );
      },
    },
    {
      id: "routes-implementation",
      description:
        "Lead recognizes an implementation ask and mentions/delegates to coder.",
      async test(t) {
        await t.send(
          "Please implement a tiny read-only comment in BudgetMutation documenting CreateBudget. Use the coder peer; do not write the code yourself.",
        );
        t.succeeded();
        t.check(t.reply, includes(/coder|implement|BudgetMutation|CreateBudget/i));
      },
    },
    {
      id: "routes-frontend",
      description:
        "Lead recognizes frontend/BFF work and mentions frontend-coder.",
      async test(t) {
        await t.send(
          "Please add a Next.js BFF route and a stub /projects/kakeibo page. Use the frontend-coder peer; do not write the code yourself.",
        );
        t.succeeded();
        t.check(t.reply, includes(/frontend-coder|bff|projects\/kakeibo|next\.js/i));
      },
    },
  ],
});

