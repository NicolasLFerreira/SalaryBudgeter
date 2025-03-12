namespace SalaryBudgeter.Records;

internal class FinancialRecordManager : IFinancialRecordManager
{
    private Dictionary<FinancialRecordType, List<FinancialRecord>> _storage = [];

    public FinancialRecordManager()
    {
        foreach (var record in (FinancialRecordType[])Enum.GetValues(typeof(FinancialRecordType)))
        {
            _storage[record] = [];
        }
    }

    public List<FinancialRecord> this[FinancialRecordType recordType]
    {
        get => _storage[recordType];
    }

    public void Add(FinancialRecord record)
    {
        _storage[record.RecordType].Add(record);
    }

    public List<FinancialRecord> Get(FinancialRecordType recordType)
    {
        return _storage[recordType];
    }
}
