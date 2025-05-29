using test_next_13_backend_cSharp_Project.Models.Entities;

namespace test_next_13_backend_cSharp_Project.Data;

using Microsoft.EntityFrameworkCore;

public class KakeiboDbContext : DbContext
{
    public KakeiboDbContext(DbContextOptions<KakeiboDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Budget> Budgets { get; set; }

    public DbSet<Income> Incomes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Budget
        modelBuilder.Entity<Budget>(b =>
        {
            b.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();

            b.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("now()") // default on INSERT
                .ValueGeneratedOnAddOrUpdate(); // auto‐update on UPDATE

            // Define relationship: Budget → User (many-to-one)
            b.HasOne(c => c.User)
                .WithMany(u => u.Budgets)
                .HasForeignKey(c => c.UserId);
        });

        // Income
        modelBuilder.Entity<Income>()
            .HasOne(i => i.Budget)
            .WithMany(bu => bu.Incomes)
            .HasForeignKey(i => i.BudgetId)
            .OnDelete(DeleteBehavior.Cascade);


        // User
        modelBuilder.Entity<User>(u =>
        {
            u.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("now()") // default on INSERT
                .ValueGeneratedOnAdd();
        });
    }
}
