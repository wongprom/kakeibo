import { defineEval, includes } from "@cursor/bdk/evals";

export default defineEval({
  tags: ["smoke"],
  cases: [
    {
      id: "server-data-rule",
      description:
        "Frontend-coder states RSC/server-only GraphQL rules and /projects/kakeibo target without editing.",
      async test(t) {
        await t.send(
          "Read-only: Where should the Kakeibo UI live, and may client components call the C# GraphQL API directly? What should handle reads vs CRUD writes? Do not edit files.",
        );
        t.succeeded();
        t.check(t.reply, includes(/projects\/kakeibo|\/projects\/kakeibo/i));
        t.check(
          t.reply,
          includes(/server|rsc|server action|not .*direct|must not|should not/i),
        );
      },
    },
  ],
});
