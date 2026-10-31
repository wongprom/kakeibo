import { defineEval, includes } from "@cursor/bdk/evals";

export default defineEval({
  tags: ["smoke"],
  cases: [
    {
      id: "locate-create-budget",
      description:
        "Coder inspects the checkout and points at CreateBudget without inventing a new API.",
      async test(t) {
        await t.send(
          "Read-only: where is CreateBudget implemented, and which DTO does it take? Do not edit files.",
        );
        t.succeeded();
        t.check(t.reply, includes(/BudgetMutation|CreateBudget/i));
        t.check(t.reply, includes(/CreateBudgetDto|DTO|Dto/i));
      },
    },
  ],
});
