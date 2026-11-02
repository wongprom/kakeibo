# Kakeibo agent team (BDK)

**BDK** (Bot Development Kit) is Cursor’s framework for defining agents as
versioned Markdown + TypeScript. Docs: https://cursor.com/docs/bdk

## Current layout (step 3)

| Agent | Role |
| --- | --- |
| `lead` | User-facing router |
| `architect` | Advisory schema / GraphQL / migrations |
| `coder` | Backend implementer (C# checkout) |
| `frontend-coder` | Frontend: RSC UI + server-only GraphQL + Server Actions (`test-next-13`) |

Later: `designer`, `tester`, `deployer`.

Peers (one-way): lead → architect, coder, frontend-coder.

## Product locks

- Full app at `/projects/kakeibo`
- Browser never calls C# GraphQL directly
  - Reads: RSC → server-only helpers → C# HotChocolate
  - Writes: Server Actions → same helpers → C#
  - Route Handlers only when HTTP is truly required
- UI kit: **shadcn/ui** + Tailwind
- Auth: **Clerk** on the frontend (not Supabase Auth)
- DB: Supabase **Postgres** via EF Core / Npgsql (storage/auth products later if needed)
- **Language:** product UI, copy, and in-app content are **English**
- v1: plan month + log spending + review
- Repos stay separate: `kakeibo` + `test-next-13` (FE target Next.js 16+)

## Kakeibo core (non-negotiable)

The product must follow traditional Kakeibo intent. Technology must not
hollow it out:

- Core loop is **plan → log spending → review / reflect** — not
  “smart budget” automation that decides for the user.
- **Reflection and mindful choice** stay visible in UX (prompts,
  confirmations, pause). Do not hide them behind auto-categorize or
  auto-optimize flows.
- Future AI (if any) is a **mirror / coach the user steers** — suggestions
  need explicit confirmation; never silent auto-apply.

## Later (inspiration — not v1)

Out of scope until the core loop works. Do not implement or route as v1 work:

- AI coaching (Semantic Kernel / Claude / Vercel AI SDK / LangChain), AI
  category suggestions, reflection chat
- GraphQL subscriptions for streamed AI replies
- Browser Apollo/Urql as the default data client (server-only layer stays default)
- Supabase Auth replacing Clerk; receipt upload / AI receipt parsing

## Local layout for frontend-coder

```text
parent/
  kakeibo/          # this repo
  test-next-13/     # sibling clone
```

Or set `KAKEIBO_FRONTEND_ROOT` to the absolute path of `test-next-13`.

## Run locally (playground)

```bash
# from kakeibo repo root
npx --yes "@cursor/bdk@0.2.25" dev ./kakeibo-agents
# open http://127.0.0.1:3000/lead/playground
```

Confirm handoffs on each specialist’s **Runs** tab (`type: mcp`).

## Caution

`coder` and `frontend-coder` write into real git working trees. Use clean
branches, review diffs, stop with Ctrl+C.

## Secrets & tickets

Repos are **public**. Use public GitHub Issues for tickets. **Never** put
secrets in issues/PRs/commits. Each agent has always-on instructions plus
skill `public-repo-safety`.
