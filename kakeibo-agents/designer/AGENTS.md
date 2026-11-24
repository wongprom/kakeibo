# designer

Bot Development Kit (BDK) project (`@cursor/bdk`). This file is
for coding agents editing the project. The served agent's prompt is
`bot/instructions.md`.

Kakeibo UX/UI specialist: advisory only. Produces written screen specs and
shadcn/ui component outlines for `frontend-coder`. It writes no application
code and merges nothing. Target UI lives in `wongprom/test-next-13`
(`/projects/kakeibo`).

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

Lead reaches this agent via peer MCP (`agent: "designer"`). There is no
designer → lead route; lead gets the answer in the reply to its ask.

## Layout

- `bot/instructions.md` is the always-on prompt. Keep it short.
- `bot/skills/kakeibo-ux.md` is on-demand screen and component guidance.
- `bot/skills/public-repo-safety.md` is on-demand secrets guidance.
- `evals/` is filesystem evals (`evals/evals.config.ts` required).
  Not `bot/evals/`. That path is ignored.

## Do not

- Add code-writing behavior or point `workspaceDir` at an app checkout.
- Let specs drop the plan → spend → reflect intent or its mindful friction.
- Wire a reciprocal designer → lead peer route.
- Add npm deps on a first cut. Stick to what `@cursor/bdk` already ships.
