using SalaryBudgeter.Records;

namespace SalaryBudgeter.Budgeting
{
    public interface IBudgetCalculator
    {
        List<FinancialRecord> Calculate();
    }
}