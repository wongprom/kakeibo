using System.ComponentModel.DataAnnotations.Schema;

namespace test_next_13_backend_cSharp_Project.Models.Entities;
// User entity for Supabase: lowercase [Column] names, all properties required.
public class User
{
    [Column("id")]
    public required int Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("email")]
    public required string Email { get; set; }

    [Column("password")]
    public required string Password { get; set; }
}
