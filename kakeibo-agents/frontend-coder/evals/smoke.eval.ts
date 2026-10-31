import { defineEval, includes } from "@cursor/bdk/evals";

export default defineEval({
  tags: ["smoke"],
  cases: [
    {
      id: "bff-rule",
      description:
        "Frontend-coder states the BFF rule and /projects/kakeibo target without editing.",
      async test(t) {
        await t.send(
          "Read-only: Where should the Kakeibo UI live, and may client components call the C# GraphQL API directly? Do not edit files.",
        );
        t.succeeded();
        t.check(t.reply, includes(/projects\/kakeibo|\/projects\/kakeibo/i));
        t.check(t.reply, includes(/bff|next\.js|server|not .*direct|must not|should not/i));
      },
    },
  ],
});
