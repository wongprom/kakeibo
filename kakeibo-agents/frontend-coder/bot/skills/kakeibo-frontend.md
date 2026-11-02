---
description: "Load when implementing Kakeibo UI routes, layout, or portfolio integration in test-next-13."
---

# Kakeibo frontend layout

Repo: `wongprom/test-next-13` (Next.js App Router, **shadcn/ui**, Tailwind,
Clerk; upgrade target Next **16+** with stable RSC + Server Actions).

## Target paths

| Path | Role |
| --- | --- |
| `app/projects/kakeibo/**` | Kakeibo full-screen app (RSC by default) |
| `lib/kakeibo/**` | Server-only GraphQL helpers + documents |
| `components/ui/**` (typical shadcn) | Shared shadcn primitives — reuse, don’t reinvent |
| `app/projects/page.tsx` | Projects index — add a card linking to `/projects/kakeibo` when ready |
| `app/projects/epigram/**` | Neighbor pattern reference (not chrome to copy blindly) |
| `app/api/kakeibo/**` | Optional HTTP endpoints — not the default data path |
| `middleware.ts` | Clerk middleware — extend carefully for kakeibo routes |

## v1 screens (core loop)

1. **Plan month** — income, fixed outflows, available, savings goal, weekly allowance  
2. **Log spending** — weekly/category entries (web-friendly; not a pure paper grid clone)  
3. **Review** — end-of-month reflection prompts (human prompts first; AI coaching later)

## UX notes

- Full-screen product shell under `/projects/kakeibo` (minimal portfolio sidebar).
- Build with **shadcn/ui** + Tailwind; prefer existing primitives over custom chrome.
- Prefer flows + lists/modals over one giant spreadsheet on mobile later; desktop ledger OK for v1.
- Primary action color in existing mocks: dark blue; currency **Kr**.
- Auth is **Clerk**, not Supabase Auth.
