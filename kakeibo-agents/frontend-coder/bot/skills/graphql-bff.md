---
description: "Load when wiring Next.js BFF routes that call the Kakeibo C# HotChocolate GraphQL API."
---

# GraphQL BFF bridge

## Rule

```text
Browser  →  Next.js (BFF)  →  C# HotChocolate GraphQL
```

- Client components must **not** call the C# URL directly.
- Put secrets and the upstream GraphQL URL in **server** env only
  (e.g. `KAKEIBO_GRAPHQL_URL`), never `NEXT_PUBLIC_*` for the upstream API.

## Suggested shape

- `app/api/kakeibo/graphql/route.ts` — forward GraphQL POST body upstream, or
- thin REST-ish BFF endpoints per use case (`/api/kakeibo/budget`, etc.) that
  run typed GraphQL documents server-side.

Forward Clerk/session identity as headers the C# API will eventually accept;
until backend auth exists, document placeholders and keep BFF as the single seam.

## Contract with backend (`coder` / `architect`)

Current C# surface includes users/budgets/income/fixed expenses. When UI needs
week grids, categories, or reflections not yet in the API, list **Needs from
backend** instead of inventing a second database in Next/Prisma for Kakeibo
core data.
