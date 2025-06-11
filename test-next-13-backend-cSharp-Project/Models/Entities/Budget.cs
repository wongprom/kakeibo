using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_next_13_backend_cSharp_Project.Models.Entities
{
    public class Budget
    {
        // PK, identity column
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        // The budget’s target date (the month/day you’re budgeting)
        [Column("date")]
        public required DateTime Date { get; set; }

        // When the row was created (filled by DB)
        [Column("created_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; private set; }

        // Last time the row was modified
        [Column("updated_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; private set; }

        // Available funds in this budget period
        [Column("available_funds")]
        public decimal AvailableFunds { get; set; } = 0m;

        // Monthly spending target
        [Column("spending_goal_month")]
        public decimal SpendingGoalMonth { get; set; } = 0m;

        // Number of weeks in the month (4 or 5)
        [Column("num_of_weeks")]
        public int NumOfWeeks { get; set; }

        // Amount you aim to save
        [Column("savings_goal")]
        public decimal SavingsGoal { get; set; } = 0m;

        // Optional description
        [Column("savings_goal_description")]
        public string? SavingsGoalDescription { get; set; }

        // Optional notes
        [Column("notes")]
        public string? Notes { get; set; }

        // FK → owning User
        [Column("user_id")]
        public int UserId { get; set; }

        // Navigation back to User
        public User User { get; set; } = default!;

        // foreign key
        public int? IncomeId { get; set; }

        public ICollection<Income> Incomes { get; set; } = new List<Income>();

        public ICollection<FixedExpense> FixedExpenses { get; set; } = new List<FixedExpense>();
    }
}
