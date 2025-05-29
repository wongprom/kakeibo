using System.ComponentModel.DataAnnotations.Schema;

namespace test_next_13_backend_cSharp_Project.Models.Entities;

public class Income
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    public DateTime CreatedAt { get; private set; }

    [Column("source")]
    public required string Source { get; set; }

    public required decimal Amount { get; set; }

    // When do you expect to get Amount? YYYY-MM-DD
    public DateTime ReceivedAmountDate { get; set; }

    public int BudgetId { get; set; } // Required FK

    public Budget Budget { get; set; } = null!; // Navigation
}
