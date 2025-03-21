using SalaryBudgeter.Entries;

namespace SalaryBudgeter.Budgeting;

internal class BudgetManager(IEntryManager financialRecordManager) : IBudgetManager
{
    private IEntryManager _financialRecordManager = financialRecordManager;

    
}
