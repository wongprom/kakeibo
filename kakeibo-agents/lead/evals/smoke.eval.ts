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
        "Lead recognizes frontend server-data work and mentions frontend-coder.",
      async test(t) {
        await t.send(
          "Please add a stub /projects/kakeibo RSC page and a server-only GraphQL helper toward C#. Use the frontend-coder peer; do not write the code yourself.",
        );
        t.succeeded();
        t.check(
          t.reply,
          includes(/frontend-coder|server|rsc|projects\/kakeibo|next\.js/i),
        );
      },
    },
    {
      id: "routes-deploy-check",
      description:
        "Lead delegates a Vercel deployment check to deployer instead of doing it itself.",
      async test(t) {
        await t.send(
          "Did the latest main commit of wongprom/test-next-13 deploy to Vercel? Use the deployer peer; do not check yourself.",
        );
        t.succeeded();
        t.check(t.reply, includes(/deployer|vercel|deploy|succeeded|failed|pending/i));
      },
    },
    {
      id: "routes-design-spec",
      description:
        "Lead delegates a screen spec to designer instead of writing UI code.",
      async test(t) {
        await t.send(
          "I need a UX spec for the Plan month screen: layout, shadcn components, copy and accessibility. Use the designer peer; do not write code yourself.",
        );
        t.succeeded();
        t.check(t.reply, includes(/designer|spec|layout|shadcn|accessib/i));
      },
    },
    {
      id: "routes-verification",
      description:
        "Lead delegates verification of a PR to tester instead of running checks itself.",
      async test(t) {
        await t.send(
          "Please verify PR 1 in wongprom/test-next-13: lint, build, and review against the product locks. Use the tester peer; do not check yourself.",
        );
        t.succeeded();
        t.check(t.reply, includes(/tester|verify|lint|build|pass|fail|blocked/i));
      },
    },
    {
      id: "feature-flow-asks-before-next-stage",
      description:
        "Lead follows the default feature flow and checks in with the user before the next stage.",
      async test(t) {
        await t.send(
          "I want a new feature: let users set a weekly allowance on the Plan month screen. How will we go about it? Plan the stages only; do not start work.",
        );
        t.succeeded();
        t.check(t.reply, includes(/architect/i));
        t.check(t.reply, includes(/designer/i));
        t.check(t.reply, includes(/tester/i));
      },
    },
  ],
});

