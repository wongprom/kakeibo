using System.ComponentModel.DataAnnotations.Schema;

namespace test_next_13_backend_cSharp_Project.Models.Entities;

public class FixedExpense
{
    [Column("id")]
    public int Id { get; set; }

    [Column("amount")]
    public required decimal Amount { get; set; }

    [Column("date")]
    public required DateOnly Date { get; set; }

    [Column("category")]
    public required string Category { get; set; }

    [Column("budget_id")]
    public int BudgetId { get; set; } // Required FK

    public Budget Budget { get; set; } = null!; // Navigation
}
