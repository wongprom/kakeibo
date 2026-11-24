---
description: "Load when verifying a Kakeibo change: which commands to run per repo and what to check in a diff."
---

# Kakeibo verification

## Commands

| Repo | Command | Notes |
| --- | --- | --- |
| `kakeibo` (C#) | `dotnet build` | from repo root (solution file) |
| `kakeibo` (C#) | `dotnet test` | `Kakeibo.Tests`; needs no DB for unit tests |
| `kakeibo` agents | `npm run check` | in each `kakeibo-agents/<agent>` (needs `npm ci`) |
| `kakeibo` agents | `npx --yes "@cursor/bdk@0.2.25" validate --dir .` | per agent; run under Node |
| `test-next-13` | `npm run lint` | |
| `test-next-13` | `npx tsc --noEmit` | if no typecheck script |
| `test-next-13` | `npm run build` | needs only env **names**; if build needs missing env values, report `blocked` |
| `test-next-13` | `npm test` | only if a test script exists |

Install deps only when `node_modules` is missing (`npm ci`). Never print
`.env` values.

## Diff checklist

- Data access: no Client Component imports the GraphQL client; upstream URL
  is not in `NEXT_PUBLIC_*`; mutations are Server Actions with revalidation.
- UI: shadcn/ui primitives reused; English copy; `Kr` currency; labels and
  focus handled per the designer spec.
- Kakeibo core: reflection prompts and confirmations still present; no
  silent auto-categorize/auto-optimize; no AI auto-apply.
- Backend: migrations match entity changes; snake_case DB columns; GraphQL
  changes match architect's contract; tests cover new logic.
- Scope: no unrelated files; no secrets, `.env`, or tokens in the diff.
- Agents: `bdk validate` passes; lead peers are one-way (no reciprocal route).

## Test proposals

Name the file, the case, and the assertion. Prefer small unit tests on pure
logic (`BudgetUtils`-style) before integration tests.
