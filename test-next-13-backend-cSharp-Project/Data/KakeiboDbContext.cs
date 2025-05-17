using test_next_13_backend_cSharp_Project.Models.Entities;

namespace test_next_13_backend_cSharp_Project.Data;

using Microsoft.EntityFrameworkCore;

public class KakeiboDbContext : DbContext
{
  public KakeiboDbContext(DbContextOptions<KakeiboDbContext> options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>().ToTable("User");
  }
}