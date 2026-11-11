# coder

Bot Development Kit (BDK) project (`@cursor/bdk`). This file is
for coding agents editing the project. The served agent's prompt is
`bot/instructions.md`.

Kakeibo implementer: edits the real C# checkout via
`local.workspaceDir` → repo root.

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

Serve with siblings from the parent folder:

```bash
npx --yes "@cursor/bdk@0.2.25" dev ../
```

Lead reaches this agent via peer MCP (`agent: "coder"`).

## Layout

- `bot/instructions.md` is the always-on prompt.
- `bot/skills/kakeibo-backend.md` is on-demand backend navigation.
- `bot/agent.ts` sets `local.workspaceDir` to the monorepo root.
- `evals/` is filesystem evals (`evals/evals.config.ts` required).

## Do not

- Point `workspaceDir` at `kakeibo-agents/coder` itself (edits would miss the app).
- Add deployer/write gates here — stay an implementer.
- Add npm deps on a first cut beyond what `@cursor/bdk` ships.
