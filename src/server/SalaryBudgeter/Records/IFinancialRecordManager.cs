namespace SalaryBudgeter.Records
{
    /// <summary>
    /// Abstracts access to a storage of financial records
    /// </summary>
    public interface IFinancialRecordManager
    {
        void Add(FinancialRecord record);
        void AddRange(IEnumerable<FinancialRecord> records);
        IEnumerable<FinancialRecord> Get(string name);
        IEnumerable<FinancialRecord> Get(FinancialRecordType recordType);
        IEnumerable<FinancialRecord> Get(string name, FinancialRecordType recordType);
        decimal GetTotal(FinancialRecordType recordType);
        // void Remove(Guid id); // Will be implemented once id system has been put in place.
        void Clear();
    }
}