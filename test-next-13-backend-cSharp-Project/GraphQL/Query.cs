using test_next_13_backend_cSharp_Project.Data;
using test_next_13_backend_cSharp_Project.Models.Entities;

namespace test_next_13_backend_cSharp_Project.GraphQL;

public class Query
{
    public IQueryable<User> GetUsers([Service] KakeiboDbContext db)
        => db.Users;
}
