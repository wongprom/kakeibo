---
description: "Load when wiring Kakeibo data access from Next.js to the C# HotChocolate GraphQL API (RSC reads, Server Actions, optional Route Handlers)."
---

# Kakeibo server GraphQL layer

## Locked flow

```text
Read:    RSC  →  server-only GraphQL helper  →  C# HotChocolate
Write:   UI / form  →  Server Action  →  same helper  →  C#
HTTP:    app/api/kakeibo/**  only if a Client Component or external caller needs HTTP
```

- Browser / Client Components must **not** call the C# URL directly.
- Put the upstream GraphQL URL in **server** env only
  (e.g. `KAKEIBO_GRAPHQL_URL`), never `NEXT_PUBLIC_*`.

## Suggested shape

| Path | Role |
| --- | --- |
| `lib/kakeibo/client.ts` (or similar) | Server-only GraphQL `fetch` / thin client |
| `lib/kakeibo/queries.ts` / `mutations.ts` | Typed documents for plan / spend / review |
| `app/projects/kakeibo/**/page.tsx` | RSC: call helpers, render |
| `app/projects/kakeibo/**/actions.ts` | `'use server'` CRUD; then `revalidatePath` / `updateTag` |
| `app/api/kakeibo/**` | Exception path only |

Prefer a small typed client (`graphql-request` or `fetch` + codegen) for the
server layer. Add Apollo (`@apollo/client-integration-nextjs`) later only if
interactive ledger UX needs a normalized client cache.

## Contract with backend (`coder` / `architect`)

Current C# surface includes users/budgets/income/fixed expenses. When UI needs
week grids, categories, or reflections not yet in the API, list **Needs from
backend** instead of inventing a second database in Next/Prisma for Kakeibo
core data.

Forward Clerk/session identity as headers the C# API will eventually accept;
until backend auth exists, document placeholders and keep this server layer as
the single seam to C#.
