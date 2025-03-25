namespace SalaryBudgeter.Clocking;

public interface IHourScheme
{
    void Add(int hours, int repeat);
    void Add(WeekRoster weekRoster, int repeats = 1);
    List<WeekRoster> Get();
}