using AutoMapper;

using test_next_13_backend_cSharp_Project.DTOs;
using test_next_13_backend_cSharp_Project.Models.Entities;

namespace test_next_13_backend_cSharp_Project.Mapping;

public class FixedExpenseProfile : Profile
{
    public FixedExpenseProfile()
    {
        CreateMap<FixedExpense, FixedExpenseDto>();
        CreateMap<CreateFixedExpenseDto, FixedExpense>();
    }
}
