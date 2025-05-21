using AutoMapper;

using test_next_13_backend_cSharp_Project.Models.Entities;
using test_next_13_backend_cSharp_Project.DTOs;

namespace test_next_13_backend_cSharp_Project.Mapping
{
    public sealed class BudgetProfile : Profile
    {
        public BudgetProfile()
        {
            CreateMap<Budget, BudgetDto>();
            CreateMap<CreateBudgetDto, Budget>();
        }
    }
}
