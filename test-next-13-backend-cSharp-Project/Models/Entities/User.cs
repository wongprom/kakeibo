using System.ComponentModel.DataAnnotations.Schema;

namespace test_next_13_backend_cSharp_Project.Models.Entities;

// User entity for Supabase: lowercase [Column] names, all properties required.
public class User
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // value comes from DB
    public int Id { get; private set; } // no setter = read-only

    [Column("name")]
    public required string Name { get; set; }

    [Column("email")]
    public required string Email { get; set; }

    [Column("password")]
    public required string Password { get; set; }

    [Column("created_at")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; private set; }
}
