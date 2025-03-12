using SalaryBudgeter.Records;

namespace SalaryBudgeter.Budgeting
{
    internal class BudgetManager(IFinancialRecordManager financialRecordManager) : IBudgetManager
    {
        private IFinancialRecordManager _financialRecordManager = financialRecordManager;

        
    }
}
