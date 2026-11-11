---
description: "Load when designing or reviewing Kakeibo data model, EF entities, relations, GraphQL surface, or migrations against the current backend."
---

# Kakeibo domain (current snapshot)

Source app: `test-next-13-backend-cSharp-Project` (ASP.NET Core + EF Core
Npgsql + HotChocolate GraphQL). DB column names are snake_case via
`[Column]`.

## Entities

### User

| Field | Type | Notes |
| --- | --- | --- |
| `Id` | int | identity PK |
| `Name` | string | required |
| `Email` | string | required |
| `Password` | string | required; stored as plaintext today (tech debt) |
| `CreatedAt` | DateTime | DB default `now()` |
| `Budgets` | collection | navigation |

### Budget

| Field | Type | Notes |
| --- | --- | --- |
| `Id` | int | identity PK |
| `Date` | DateTime | budget period target date |
| `CreatedAt` / `UpdatedAt` | DateTime | DB defaults `now()` |
| `AvailableFunds` | decimal | default 0 |
| `SpendingGoalMonth` | decimal | default 0 |
| `NumOfWeeks` | int | set on create via `BudgetUtils.CalculateWeeksInMonth` |
| `SavingsGoal` | decimal | default 0 |
| `SavingsGoalDescription` | string? | optional |
| `Notes` | string? | optional |
| `UserId` | int | FK → User |
| `IncomeId` | int? | present on entity; primary income link is via `Incomes` collection |
| `Incomes` / `FixedExpenses` | collections | cascade delete from Budget |

### Income

| Field | Type | Notes |
| --- | --- | --- |
| `Id` | int | identity PK |
| `CreatedAt` | DateTime | |
| `Source` | string | required |
| `Amount` | decimal | required |
| `ReceivedAmountDate` | DateOnly | expected receipt date |
| `BudgetId` | int | FK → Budget, cascade |

### FixedExpense

| Field | Type | Notes |
| --- | --- | --- |
| `Id` | int | PK |
| `Amount` | decimal | required |
| `Date` | DateOnly | required |
| `Category` | string | required (free-text today) |
| `BudgetId` | int | FK → Budget, cascade |

## Relationships

```
User 1—* Budget
Budget 1—* Income          (cascade)
Budget 1—* FixedExpense    (cascade)
```

## GraphQL (today)

Queries: `UserQuery`, `BudgetQuery`  
Mutations: `UserMutation`, `BudgetMutation` with:

- `CreateBudget`
- `CreateIncome`
- `CreateFixedExpense`

DTOs live under `DTOs/`; AutoMapper profiles under `Mapping/`.

## Design conventions for new work

- Prefer additive migrations.
- Keep snake_case DB columns aligned with existing `[Column]` style.
- Cascade deletes stay on budget-owned children unless a plan says otherwise.
- Free-text `FixedExpense.Category` may become a lookup/enum later — call that out when relevant.
- Keep the domain aligned with Kakeibo core (plan → spend → review/reflect);
  do not invent defaults that auto-decide away user intentionality.
