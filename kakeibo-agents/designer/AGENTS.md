# designer

Bot Development Kit (BDK) project (`@cursor/bdk`). This file is
for coding agents editing the project. The served agent's prompt is
`bot/instructions.md`.

Kakeibo UX/UI specialist: advisory only. Produces written screen specs and
shadcn/ui component outlines for `frontend-coder`. It writes no application
code, edits nothing in Figma, and merges nothing. Target UI lives in `wongprom/test-next-13`
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

## Figma (read-only)

Two host-only connections (`bot/host-connections/`, never shown to the model):

- `figma.ts`: `cursorAccount: true`, the account's Figma plugin MCP. Tokens stay
  on the Cursor backend; nothing secret is in the repo or on the serve host.
- `figma-desktop.ts`: fallback to the Figma desktop app's local MCP
  (`http://127.0.0.1:3845/mcp`, no token). Skipped silently if not running.

The model only gets `bot/tools/figma_list.ts` and `figma_read.ts`. They use
`bot/lib/figma.ts`, which holds the read-only allowlist and finds the real
tool names: `cursorAccount` tool names may carry a connector prefix, so the
wrapper matches a bare name or a `*figma*...-<tool>` name. Write tools are not
in the allowlist and are refused.

Why not the earlier setup (`cursorAccount` + `servers: ["figma"]` + advertised
`tools` allowlist + `optional: true`): `servers` goes verbatim to Cursor's
backend, which keys connectors by an internal identifier (`user-<name>`,
`dashboard-<name>`, `dashboard-team-<id>-<name>`), and the exact-name `tools`
filter matches only unprefixed names. Either mismatch yields no tools, and
`optional: true` hides that, so the designer just said "Figma not available".

Why not `{ url: "https://mcp.figma.com/mcp", oauth: true }`: BDK 0.2.25's
`mcp oauth` registers a client dynamically and Figma answers 403 (checked).
Never copy host-OAuth tokens (`~/.config/agent-serve/mcp-auth.json`) into the
repo.

Inspect what the designer really sees (running `dev`):
`curl -s http://127.0.0.1:3000/designer/v1/tools`, or
`npx --yes "@cursor/bdk@0.2.25" call figma_list --dir ./kakeibo-agents/designer`.
User setup is in `../README.md`.

## Layout

- `bot/instructions.md` is the always-on prompt. Keep it short.
- `bot/skills/kakeibo-ux.md` is on-demand screen and component guidance.
- `bot/skills/kakeibo-figma.md` is on-demand Figma-to-spec translation guidance.
- `bot/host-connections/`, `bot/tools/figma_*.ts`, `bot/lib/figma.ts` are the read-only Figma access.
- `bot/skills/public-repo-safety.md` is on-demand secrets guidance.
- `evals/` is filesystem evals (`evals/evals.config.ts` required).
  Not `bot/evals/`. That path is ignored.

## Do not

- Add Figma write tools to `READ_ONLY_FIGMA_TOOLS`, or move the Figma connections out of `host-connections/`.
- Commit Figma tokens, `mcp-auth.json`, or file links that carry secrets.
- Add code-writing behavior or point `workspaceDir` at an app checkout.
- Let specs drop the plan → spend → reflect intent or its mindful friction.
- Wire a reciprocal designer → lead peer route.
- Add npm deps on a first cut. Stick to what `@cursor/bdk` already ships.
