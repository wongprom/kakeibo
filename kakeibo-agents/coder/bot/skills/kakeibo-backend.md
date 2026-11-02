---
description: "Load when implementing or navigating the Kakeibo ASP.NET / EF / GraphQL backend layout and conventions."
---

# Kakeibo backend layout

Repo paths (from workspace root):

| Path | Role |
| --- | --- |
| `test-next-13-backend-cSharp-Project/` | ASP.NET Core app |
| `test-next-13-backend-cSharp-Project/Models/Entities/` | EF entities |
| `test-next-13-backend-cSharp-Project/Data/KakeiboDbContext.cs` | DbSets + relationships |
| `test-next-13-backend-cSharp-Project/DTOs/` | GraphQL/API DTOs |
| `test-next-13-backend-cSharp-Project/Mapping/` | AutoMapper profiles |
| `test-next-13-backend-cSharp-Project/GraphQL/Queries/` | Query type extensions |
| `test-next-13-backend-cSharp-Project/GraphQL/Mutations/` | Mutation type extensions |
| `test-next-13-backend-cSharp-Project/Migrations/` | EF migrations |
| `test-next-13-backend-cSharp-Project/Utils/` | helpers (e.g. `BudgetUtils`) |
| `Kakeibo.Tests/` | test project |
| `test-next-13-backend-cSharp-Solution.sln` | solution |

## Stack

- EF Core + Npgsql (**Supabase Postgres** — database host, not Supabase Auth)
- HotChocolate GraphQL (`Program.cs` registers query/mutation extensions)
- AutoMapper for DTO ↔ entity
- Frontend identity is **Clerk**; backend JWT validation can come later.
  Do not add Supabase Auth as the v1 auth path.
- AI (Semantic Kernel / Claude coaching, streamed reflections) is **later
  inspiration**, not required for v1 plan/spend/review mutations.

## Conventions

- DB columns: snake_case via `[Column("…")]`
- New GraphQL ops: add/extend files under `GraphQL/Queries` or `Mutations`,
  register extensions in `Program.cs` when adding a new type class
- Budget-owned children (`Income`, `FixedExpense`) cascade delete
- Current mutations include `CreateBudget`, `CreateIncome`, `CreateFixedExpense`

## Domain snapshot

Entities today: `User`, `Budget`, `Income`, `FixedExpense`.
`FixedExpense.Category` is free-text string (may become a lookup later).
