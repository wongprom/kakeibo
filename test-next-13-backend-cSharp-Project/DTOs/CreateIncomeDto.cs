namespace test_next_13_backend_cSharp_Project.DTOs;

public sealed record CreateIncomeDto(
    string Source,
    decimal Amount,
    DateOnly ReceivedAmountDate,
    int BudgetId
);
