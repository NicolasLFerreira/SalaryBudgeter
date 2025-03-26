using SalaryBudgeterConsole.Entries;

namespace SalaryBudgeterConsole.Budgeting;

public interface IBudgetCalculator
{
    List<Entry> Calculate();
}