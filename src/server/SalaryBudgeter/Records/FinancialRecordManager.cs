using System.Linq;

namespace SalaryBudgeter.Records;

internal class FinancialRecordManager : IFinancialRecordManager
{
    // Temporary way of storage until a proper one is developed.
    private readonly Dictionary<FinancialRecordType, List<FinancialRecord>> _storage = [];

    public FinancialRecordManager()
    {
        Initialise();
    }

    public void Add(FinancialRecord record)
    {
        _storage[record.RecordType].Add(record);
    }

    public void AddRange(IEnumerable<FinancialRecord> records)
    {
        foreach (var record in records)
        {
            Add(record);
        }
    }

    public IEnumerable<FinancialRecord> Get(string name)
    {
        foreach (var list in _storage)
        {
            yield return (FinancialRecord)list.Value.Where(item => item.Name == name);
        }
    }

    public IEnumerable<FinancialRecord> Get(FinancialRecordType recordType)
    {
        return _storage[recordType];
    }

    public IEnumerable<FinancialRecord> Get(string name, FinancialRecordType recordType)
    {
        return _storage[recordType].Where(record => record.Name == name);
    }

    public decimal GetTotal(FinancialRecordType recordType)
    {
        return Get(recordType).Sum(record => record.Amount);
    }

    public void Clear()
    {
        _storage.Clear();
        Initialise();
    }

    private void Initialise()
    {
        foreach (var type in (FinancialRecordType[])Enum.GetValues(typeof(FinancialRecordType)))
        {
            _storage[type] = [];
        }
    }
}
