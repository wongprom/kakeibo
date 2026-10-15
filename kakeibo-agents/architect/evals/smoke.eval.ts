import { defineEval, includes } from "@cursor/bdk/evals";

export default defineEval({
  tags: ["smoke"],
  cases: [
    {
      id: "category-lookup",
      description:
        "Architect returns a structured schema/migration plan for expense categories.",
      async test(t) {
        await t.send(
          "We want FixedExpense.Category to become a reusable category entity instead of free text. Propose the data model and GraphQL changes.",
        );
        t.succeeded();
        t.check(
          t.reply,
          includes(/entity|entities|migration|graphql|relationship|fk|foreign key/i),
        );
        t.check(t.reply, includes(/goal|open question|out of scope/i));
      },
    },
  ],
});
