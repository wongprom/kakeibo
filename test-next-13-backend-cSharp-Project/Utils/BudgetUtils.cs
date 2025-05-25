namespace test_next_13_backend_cSharp_Project.Utils;

public static class BudgetUtils
{
    public static int CalculateWeeksInMonth(int year, int month)
    {
        var daysInMonth = DateTime.DaysInMonth(year, month);
        return (int)Math.Ceiling(daysInMonth / 7.0);
    }
}
