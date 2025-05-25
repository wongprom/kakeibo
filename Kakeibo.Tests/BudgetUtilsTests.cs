using test_next_13_backend_cSharp_Project.Utils;

namespace Kakeibo.Tests;

public class BudgetUtilsTests
{
    [Theory(DisplayName = "Rounds up for all month lengths")]
    // 31-day
    [InlineData(2025, 1, 5)]
    // 30-day
    [InlineData(2025, 4, 5)]
    // 29-day leap-year Feb
    [InlineData(2024, 2, 5)]
    // 28-day non-leap Feb
    [InlineData(2025, 2, 4)]
    public void CalculateWeeksInMonth_RoundsUp_PartialWeeks(int y,int m,int expected)
    {
        // Act
        var weeks = BudgetUtils.CalculateWeeksInMonth(y, m);

        // Assert
        Assert.Equal(expected, weeks);
    }

    [Fact(DisplayName = "Throws if month < 1 or > 12")]
    public void CalculateWeeksInMonth_InvalidMonth_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            BudgetUtils.CalculateWeeksInMonth(2025, 0));
    }
}



