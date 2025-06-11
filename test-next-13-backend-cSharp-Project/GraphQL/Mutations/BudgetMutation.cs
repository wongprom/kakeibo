using AutoMapper;

using test_next_13_backend_cSharp_Project.Data;
using test_next_13_backend_cSharp_Project.DTOs;
using test_next_13_backend_cSharp_Project.Models.Entities;
using test_next_13_backend_cSharp_Project.Utils;

namespace test_next_13_backend_cSharp_Project.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class BudgetMutation
{
    public async Task<BudgetDto> CreateBudget(
        CreateBudgetDto input,
        [Service] KakeiboDbContext db,
        [Service] IMapper mapper)
    {
        var entity = mapper.Map<Budget>(input);

        entity.NumOfWeeks =
            BudgetUtils.CalculateWeeksInMonth(input.Date.Year, input.Date.Month);

        db.Budgets.Add(entity);
        await db.SaveChangesAsync();
        return mapper.Map<BudgetDto>(entity);
    }

    public async Task<IncomeDto> CreateIncome(
        CreateIncomeDto input,
        [Service] KakeiboDbContext db,
        [Service] IMapper mapper
    )
    {
        var entity = mapper.Map<Income>(input);
        db.Incomes.Add(entity);
        await db.SaveChangesAsync();
        return mapper.Map<IncomeDto>(entity);
    }

    public async Task<FixedExpenseDto> CreateFixedExpense(
        CreateFixedExpenseDto input,
        [Service] KakeiboDbContext db,
        [Service] IMapper mapper)
    {
        var entity = mapper.Map<FixedExpense>(input);
        db.FixedExpenses.Add(entity);
        await db.SaveChangesAsync();
        return mapper.Map<FixedExpenseDto>(entity);
    }
}
