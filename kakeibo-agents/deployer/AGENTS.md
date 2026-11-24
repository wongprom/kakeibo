# deployer

Bot Development Kit (BDK) project (`@cursor/bdk`). This file is
for coding agents editing the project. The served agent's prompt is
`bot/instructions.md`.

Kakeibo specialist: merges PRs (via `gh`) only when lead asks, then checks
the Vercel deployment through GitHub data and reports back. It writes no
application code. Repos: `wongprom/test-next-13` (Vercel), `wongprom/kakeibo`.

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

Lead reaches this agent via peer MCP (`agent: "deployer"`). There is no
deployer → lead route; lead gets the answer in the reply to its ask.

## Layout

- `bot/instructions.md` is the always-on prompt. Keep it short.
- `bot/skills/public-repo-safety.md` is on-demand secrets guidance.
- `evals/` is filesystem evals (`evals/evals.config.ts` required).
  Not `bot/evals/`. That path is ignored.

## Do not

- Add code-writing behavior or point `workspaceDir` at an app checkout.
- Loosen the merge gates (explicit lead ask, green checks incl. Vercel, no
  `main` merge without stated user approval).
- Wire a reciprocal deployer → lead peer route.
- Add npm deps on a first cut. Stick to what `@cursor/bdk` already ships.
