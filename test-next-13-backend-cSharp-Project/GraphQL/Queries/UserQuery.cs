using AutoMapper;

using Microsoft.EntityFrameworkCore;

using test_next_13_backend_cSharp_Project.Data;
using test_next_13_backend_cSharp_Project.DTOs;

namespace test_next_13_backend_cSharp_Project.GraphQL.Queries;

[ExtendObjectType("Query")]
public class UserQuery
{
    public IQueryable<UserDto> GetUsers(
        [Service] KakeiboDbContext db,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<UserDto>(db.Users);
    }

    public async Task<UserDto> GetUserById(
        int id,
        [Service] KakeiboDbContext db,
        [Service] IMapper mapper)
    {
        var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            throw new GraphQLException(ErrorBuilder.New()
                .SetMessage($"User with ID {id} not found.")
                .SetCode("USER_NOT_FOUND")
                .Build());
        }

        return mapper.Map<UserDto>(user);
    }
}
