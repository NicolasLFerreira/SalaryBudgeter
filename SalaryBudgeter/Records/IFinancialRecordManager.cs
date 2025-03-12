namespace SalaryBudgeter.Records
{
    internal interface IFinancialRecordManager
    {
        List<FinancialRecord> this[FinancialRecordType recordType] { get; }

        void Add(FinancialRecord record);
        List<FinancialRecord> Get(FinancialRecordType recordType);
    }
}