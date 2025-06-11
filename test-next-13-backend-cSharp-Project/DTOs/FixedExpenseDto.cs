namespace test_next_13_backend_cSharp_Project.DTOs;

public sealed record FixedExpenseDto(
    int Id,
    decimal Amount,
    DateOnly Date,
    string Category,
    int BudgetId
);
