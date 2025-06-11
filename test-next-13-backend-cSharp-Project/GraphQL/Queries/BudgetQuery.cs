using AutoMapper;

using test_next_13_backend_cSharp_Project.Data;
using test_next_13_backend_cSharp_Project.DTOs;

namespace test_next_13_backend_cSharp_Project.GraphQL.Queries;

[ExtendObjectType("Query")]
public class BudgetQuery
{
    public IQueryable<BudgetDto> GetBudgets(
        [Service] KakeiboDbContext db,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<BudgetDto>(db.Budgets);
    }

    public IQueryable<BudgetDto> GetBudgetsByUserId(
        int userId,
        [Service] KakeiboDbContext db,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<BudgetDto>(
            db.Budgets.Where(b => b.UserId == userId)
        );
    }

    public IQueryable<FixedExpenseDto> GetFixedExpenses(
        [Service] KakeiboDbContext db,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<FixedExpenseDto>(db.FixedExpenses);
    }
}
