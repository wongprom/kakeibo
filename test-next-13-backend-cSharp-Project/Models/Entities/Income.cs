using System.ComponentModel.DataAnnotations.Schema;

namespace test_next_13_backend_cSharp_Project.Models.Entities;

public class Income
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; private set; }

    [Column("source")]
    public required string Source { get; set; }

    [Column("amount")]
    public required decimal Amount { get; set; }
    
    // When do you expect to get Amount? YYYY-MM-DD
    [Column("received_amount_date")]
    public DateOnly ReceivedAmountDate { get; set; }
    
    [Column("budget_id")]
    public int BudgetId { get; set; } // Required FK

    public Budget Budget { get; set; } = null!; // Navigation
}
