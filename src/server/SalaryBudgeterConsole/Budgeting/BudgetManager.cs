using SalaryBudgeterConsole.Entries;

namespace SalaryBudgeterConsole.Budgeting;

internal class BudgetManager(IEntryManager entryManager, IBudgetCalculator budgetCalculator) : IBudgetManager
{
    private IEntryManager _entryManager = entryManager;
    private IBudgetCalculator _budgetCalculator = budgetCalculator;
}
