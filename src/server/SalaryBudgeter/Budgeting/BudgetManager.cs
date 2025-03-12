using SalaryBudgeter.Records;

namespace SalaryBudgeter.Budgeting
{
    internal class BudgetManager
    {
        private Dictionary<FinancialRecordType, List<FinancialRecord>> Records { get; }

        public BudgetManager(List<FinancialRecord> records)
        {
            Records = [];

            foreach (var type in (FinancialRecordType[])Enum.GetValues(typeof(FinancialRecordType)))
            {
                Records[type] = [];
            }
        }

        public void Distribute(List<FinancialRecord> records)
        {
            foreach (FinancialRecord record in records)
            {

            }
        }
    }
}
