# tester

Bot Development Kit (BDK) project (`@cursor/bdk`). This file is
for coding agents editing the project. The served agent's prompt is
`bot/instructions.md`.

Kakeibo verification specialist: runs or reviews lint, typecheck, build and
tests, and reviews diffs against product locks and acceptance criteria.
Read-mostly: it adds test files only when lead asks. It never merges or
deploys. Repos: `wongprom/kakeibo` (C#, `dotnet build` / `dotnet test`) and
`wongprom/test-next-13` (Next.js, `npm run lint` / `build`).

## Workspace

`local.workspaceDir` is the kakeibo repo root (like `coder`). The frontend
checkout is the sibling `../test-next-13`, or the absolute path in
`KAKEIBO_FRONTEND_ROOT`; the tester reaches it by path.

```bash
export KAKEIBO_FRONTEND_ROOT=/absolute/path/to/test-next-13
```

## Loop

```bash
npx --yes "@cursor/bdk@0.2.25" validate --dir .
npx --yes "@cursor/bdk@0.2.25" info --dir . --json
npx --yes "@cursor/bdk@0.2.25" run --dir . --message "..."
npx --yes "@cursor/bdk@0.2.25" eval --dir .
npm run check
```

Run the CLI under Node, never Bun.

## Multi-agent

Serve with the sibling lead from the parent folder:

```bash
npx --yes "@cursor/bdk@0.2.25" dev ../
```

Lead reaches this agent via peer MCP (`agent: "tester"`). There is no
tester → lead route; lead gets the answer in the reply to its ask.

## Layout

- `bot/instructions.md` is the always-on prompt. Keep it short.
- `bot/skills/kakeibo-verification.md` is on-demand check commands and review checklist.
- `bot/skills/public-repo-safety.md` is on-demand secrets guidance.
- `evals/` is filesystem evals (`evals/evals.config.ts` required).
  Not `bot/evals/`. That path is ignored.

## Do not

- Let it change application source, merge, push, deploy, or open PRs.
  Test files only, and only on lead's ask.
- Point `workspaceDir` at `kakeibo-agents/tester` itself.
- Wire a reciprocal tester → lead peer route.
- Add npm deps on a first cut. Stick to what `@cursor/bdk` already ships.
