namespace test_next_13_backend_cSharp_Project.Models.Entities;

public class User
{
   public int Id { get; set; }  // Supabase uses bigint, this maps fine
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}