namespace test_next_13_backend_cSharp_Project.DTOs;

public sealed record CreateBudgetDto(
    DateTime Date,
    decimal AvailableFunds,
    decimal SpendingGoalMonth,
    decimal SavingsGoal,
    string? SavingsGoalDescription,
    string? Notes,
    int UserId
);
