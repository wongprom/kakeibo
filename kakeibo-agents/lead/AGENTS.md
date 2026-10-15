# lead

Bot Development Kit (BDK) project (`@cursor/bdk`). This file is
for coding agents editing the project. The served agent's prompt is
`bot/instructions.md`.

Kakeibo tech lead / router. Peer connection: `bot/mcp-connections/architect.ts`
→ agent slug `architect`.

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

Must be served with `architect` as a sibling so the peer connection resolves:

```bash
npx --yes "@cursor/bdk@0.2.25" dev ../
```

Single-agent `dev` in this directory alone will warn/omit the peer.

## Layout

- `bot/instructions.md` is the always-on prompt. Keep it short.
- `bot/mcp-connections/architect.ts` is the one-way peer to the architect.
- `evals/` is filesystem evals (`evals/evals.config.ts` required).
  Not `bot/evals/`. That path is ignored.

## Do not

- Wire reciprocal architect → lead peer routes.
- Add coder/designer/tester/deployer peers until step 1 handshake is proven.
- Add npm deps on a first cut. Stick to what `@cursor/bdk` already ships.
