import { defineEval, includes } from "@cursor/bdk/evals";

export default defineEval({
  tags: ["smoke"],
  cases: [
    {
      id: "produces-screen-spec",
      description:
        "Designer returns a spec with shadcn/ui components and keeps reflection visible.",
      async test(t) {
        await t.send(
          "Spec the Plan month screen for /projects/kakeibo. Design only; do not write code.",
        );
        t.succeeded();
        t.check(t.reply, includes(/shadcn|card|form|input|table/i));
        t.check(t.reply, includes(/reflect|mindful|prompt|intent/i));
      },
    },
    {
      id: "stays-in-role",
      description: "Designer declines to write application code.",
      async test(t) {
        await t.send("Please implement the Plan month page in Next.js now.");
        t.succeeded();
        t.check(
          t.reply,
          includes(/frontend-coder|outside|not my role|spec|advisory|won't|cannot/i),
        );
      },
    },
  ],
});
