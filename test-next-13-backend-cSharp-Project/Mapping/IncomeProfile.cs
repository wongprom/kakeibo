using AutoMapper;

using test_next_13_backend_cSharp_Project.Models.Entities;
using test_next_13_backend_cSharp_Project.DTOs;

namespace test_next_13_backend_cSharp_Project.Mapping;

public sealed class IncomeProfile : Profile
{
    public IncomeProfile()
    {
        CreateMap<Income, IncomeDto>();
        // If you later add: CreateIncomeDto, map that too
        // CreateMap<CreateIncomeDto, Income>();
    }
}
