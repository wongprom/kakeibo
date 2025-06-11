using AutoMapper;

using Microsoft.EntityFrameworkCore;

using test_next_13_backend_cSharp_Project.Data;
using test_next_13_backend_cSharp_Project.DTOs;
using test_next_13_backend_cSharp_Project.Models.Entities;
using test_next_13_backend_cSharp_Project.Utils;

namespace test_next_13_backend_cSharp_Project.GraphQL;

// Query
public class Query
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

// MUTATION
public class Mutation
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
