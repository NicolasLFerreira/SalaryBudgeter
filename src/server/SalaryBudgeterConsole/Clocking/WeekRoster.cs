using System.Globalization;

namespace SalaryBudgeter.Clocking;

public class WeekRoster
{
    private readonly Dictionary<DayOfWeek, int> _weekScheme;
    private readonly int _repeat;

    public int Hours => _weekScheme.Values.Sum();
    public int Repeat => _repeat;

    public WeekRoster(int repeat)
    {
        _weekScheme = new(7);
        _repeat = repeat;
    }

    public WeekRoster(Dictionary<DayOfWeek, int> weekScheme, int repeat)
    {
        _weekScheme = weekScheme;
        _repeat = repeat;
    }
}
