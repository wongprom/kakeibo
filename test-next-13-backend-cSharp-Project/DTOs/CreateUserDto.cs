namespace test_next_13_backend_cSharp_Project.DTOs;

public sealed record CreateUserDto(
    string Name,
    string Email,
    string Password
);
