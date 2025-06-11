using AutoMapper;

using test_next_13_backend_cSharp_Project.Data;
using test_next_13_backend_cSharp_Project.DTOs;
using test_next_13_backend_cSharp_Project.Models.Entities;

namespace test_next_13_backend_cSharp_Project.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class UserMutation
{
    public async Task<UserDto> CreateUser(
        CreateUserDto input,
        [Service] KakeiboDbContext db,
        [Service] IMapper mapper)
    {
        var entity = mapper.Map<User>(input);
        db.Users.Add(entity);
        await db.SaveChangesAsync();
        return mapper.Map<UserDto>(entity);
    }
}
