namespace test_next_13_backend_cSharp_Project.DTOs;

public sealed record IncomeDto(
    int Id,
    string Source,
    decimal Amount,
    DateTime ReceivedAmountDate
);
