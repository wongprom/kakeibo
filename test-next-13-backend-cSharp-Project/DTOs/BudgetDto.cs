namespace test_next_13_backend_cSharp_Project.DTOs;

public sealed record BudgetDto(
    int Id,
    DateTime Date,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    decimal AvailableFunds,
    decimal SpendingGoalMonth,
    int NumOfWeeks,
    decimal SavingsGoal,
    string? SavingsGoalDescription,
    string? Notes,
    int UserId
);
