# frontend-coder

BDK project (`@cursor/bdk`). Served prompt: `bot/instructions.md`.

Implements Kakeibo UI with **RSC + server-only GraphQL + Server Actions**
against C#, **shadcn/ui** + Tailwind, and **Clerk** auth, in the sibling
`test-next-13` checkout. AI / Supabase Auth are later — not v1.

## Workspace

`local.workspaceDir` defaults to `../test-next-13` relative to the kakeibo
repo root. Override:

```bash
export KAKEIBO_FRONTEND_ROOT=/absolute/path/to/test-next-13
```

Clone side by side:

```text
parent/
  kakeibo/           # this agents repo
  test-next-13/      # frontend
```

## Loop

```bash
npx --yes "@cursor/bdk@0.2.25" validate --dir .
npx --yes "@cursor/bdk@0.2.25" info --dir . --json
npm run check
```

## Multi-agent

```bash
npx --yes "@cursor/bdk@0.2.25" dev ../
```

Lead peer slug: `frontend-coder`.
