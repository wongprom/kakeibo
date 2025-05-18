// DTOs/UserDto.cs  – what you **send back** to the client

namespace test_next_13_backend_cSharp_Project.DTOs;

public sealed record UserDto(
    int Id,
    string Name,
    string Email,
    DateTime CreatedAt
);
