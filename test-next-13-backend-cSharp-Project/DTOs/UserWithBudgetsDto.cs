namespace test_next_13_backend_cSharp_Project.DTOs;

public sealed record UserWithBudgetsDto(
    int Id,
    string Name,
    IReadOnlyList<BudgetDto> Budgets
);
