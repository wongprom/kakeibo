using AutoMapper;

using test_next_13_backend_cSharp_Project.Data;
using test_next_13_backend_cSharp_Project.DTOs;
using test_next_13_backend_cSharp_Project.Models.Entities;

namespace test_next_13_backend_cSharp_Project.GraphQL;

public class Query
{
    private readonly IMapper _mapper;
    private readonly KakeiboDbContext _db;

    public Query(KakeiboDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public IQueryable<UserDto> GetUsers() =>
        _mapper.ProjectTo<UserDto>(_db.Users);
}

public class Mutation
{
    private readonly IMapper _mapper;
    private readonly KakeiboDbContext _db;

    public Mutation(KakeiboDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateUser(CreateUserDto input)
    {
        var entity = _mapper.Map<User>(input);
        _db.Users.Add(entity);
        await _db.SaveChangesAsync();
        return _mapper.Map<UserDto>(entity);
    }
}
