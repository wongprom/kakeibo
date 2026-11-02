# lead

Bot Development Kit (BDK) project (`@cursor/bdk`). This file is
for coding agents editing the project. The served agent's prompt is
`bot/instructions.md`.

Kakeibo tech lead / router. Peer connections:
`architect`, `coder` (backend), `frontend-coder`.

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

Must be served with `architect`, `coder`, and `frontend-coder` as siblings so peers resolve:

```bash
npx --yes "@cursor/bdk@0.2.25" dev ../
```

Single-agent `dev` in this directory alone will warn/omit peers.

## Layout

- `bot/instructions.md` is the always-on prompt. Keep it short.
- `bot/mcp-connections/*.ts` are one-way peers to specialists.
- `evals/` is filesystem evals (`evals/evals.config.ts` required).
  Not `bot/evals/`. That path is ignored.

## Product locks (frontend)

- Prefer RSC + server-only GraphQL + Server Actions.
- Do not treat Route Handler BFF (`app/api/kakeibo/**`) as the default path.
- UI kit: shadcn/ui + Tailwind. Auth: Clerk (not Supabase Auth).
- Product language: English.
- Kakeibo core (plan → spend → reflect, mindful friction) is non-negotiable.
- AI / Semantic Kernel / Supabase Auth are later inspiration — not v1.

## Do not

- Wire reciprocal specialist → lead peer routes.
- Add designer/tester/deployer peers until frontend-coder handoff is proven.
- Add npm deps on a first cut. Stick to what `@cursor/bdk` already ships.
