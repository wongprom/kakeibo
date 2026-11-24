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

`bot/mcp-connections/figma.ts` is a `cursorAccount: true` connection to the
`figma` MCP (the Figma plugin) of the signed-in Cursor account, with a `tools` allowlist
of read-only tools. Tokens stay on the Cursor backend, so nothing secret is
stored in the repo or on the serve host.

Why not `{ url: "https://mcp.figma.com/mcp", oauth: true }`: BDK 0.2.25's
`mcp oauth` registers a client dynamically, and Figma's registration endpoint
answers 403 for it (checked), so that flow cannot complete. If Figma later
allows it, the host-OAuth alternative stores tokens in
`~/.config/agent-serve/mcp-auth.json` (mode 0600, outside the repo, or
`$AGENT_SERVE_CONFIG_DIR`); never copy that file into the repo.

One-time user setup is in `../README.md` (Figma section). `optional: true`
keeps the designer running without Figma; its prompt says so when tools are
missing.

## Layout

- `bot/instructions.md` is the always-on prompt. Keep it short.
- `bot/skills/kakeibo-ux.md` is on-demand screen and component guidance.
- `bot/skills/kakeibo-figma.md` is on-demand Figma-to-spec translation guidance.
- `bot/mcp-connections/figma.ts` is the read-only Figma connection.
- `bot/skills/public-repo-safety.md` is on-demand secrets guidance.
- `evals/` is filesystem evals (`evals/evals.config.ts` required).
  Not `bot/evals/`. That path is ignored.

## Do not

- Add Figma write tools to the `tools` allowlist, or widen `servers` beyond `figma`.
- Commit Figma tokens, `mcp-auth.json`, or file links that carry secrets.
- Add code-writing behavior or point `workspaceDir` at an app checkout.
- Let specs drop the plan → spend → reflect intent or its mindful friction.
- Wire a reciprocal designer → lead peer route.
- Add npm deps on a first cut. Stick to what `@cursor/bdk` already ships.
