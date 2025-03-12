using SalaryBudgeter.Records;

namespace SalaryBudgeter.Budgeting
{
    public interface IBudgetCalculator
    {
        decimal TotalExpenses { get; }
        decimal TotalIncomes { get; }
        decimal TotalSavings { get; }

        List<FinancialRecord> Calculate();
        decimal CalculateExpenses();
        decimal CalculateIncomes();
    }
}