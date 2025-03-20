using SalaryBudgeter.Entries;

namespace SalaryBudgeter.Budgeting
{
    public interface IBudgetCalculator
    {
        List<Entry> Calculate();
    }
}