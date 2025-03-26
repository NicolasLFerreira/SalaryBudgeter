namespace SalaryBudgeterConsole.Clocking;

internal class HourScheme(List<WeekRoster> weeks) : IHourScheme
{
    private readonly List<WeekRoster> Weeks = weeks;

    public void Add(int hours, int repeat)
    {
        Weeks.Add(new(new() { { DayOfWeek.Monday, hours } }, repeat));
    }

    public void Add(WeekRoster weekRoster, int repeat = 1)
    {
        Weeks.Add(weekRoster);
    }

    public List<WeekRoster> Get()
    {
        return Weeks;
    }
}
