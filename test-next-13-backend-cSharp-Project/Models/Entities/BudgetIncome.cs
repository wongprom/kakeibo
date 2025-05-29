using System.ComponentModel.DataAnnotations.Schema;

namespace test_next_13_backend_cSharp_Project.Models.Entities;

public class BudgetIncome
{
    [Column("budget_id")]
    public int BudgetId { get; set; }

    public Budget Budget { get; set; } = null!;

    [Column("income_id")]
    public int IncomeId { get; set; }

    public Income Income { get; set; } = null!;
}
