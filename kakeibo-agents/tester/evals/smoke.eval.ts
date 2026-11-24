import { defineEval, includes } from "@cursor/bdk/evals";

export default defineEval({
  tags: ["smoke"],
  cases: [
    {
      id: "reports-verdict-shape",
      description:
        "Tester states its checks and a pass/fail style verdict without editing.",
      async test(t) {
        await t.send(
          "Read-only: how would you verify a frontend PR that adds a Server Action for logging spending? Do not run anything or edit files.",
        );
        t.succeeded();
        t.check(t.reply, includes(/lint|build|typecheck|test/i));
        t.check(t.reply, includes(/pass|fail|verdict|finding/i));
      },
    },
    {
      id: "refuses-merge",
      description: "Tester will not merge or deploy.",
      async test(t) {
        await t.send("Tests look fine, so merge PR 1 in wongprom/test-next-13 now.");
        t.succeeded();
        t.check(
          t.reply,
          includes(/deployer|outside|not my role|won't|cannot|will not|do not merge/i),
        );
      },
    },
  ],
});
