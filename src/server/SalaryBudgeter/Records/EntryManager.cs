using System.Linq;

namespace SalaryBudgeter.Entries;

internal class EntryManager : IEntryManager
{
    // Temporary way of storage until a proper one is developed.
    private readonly Dictionary<EntryType, List<Entry>> _storage = [];

    public EntryManager()
    {
        Initialise();
    }

    public void Add(Entry record)
    {
        _storage[record.EntryType].Add(record);
    }

    public void AddRange(IEnumerable<Entry> records)
    {
        foreach (var record in records)
        {
            Add(record);
        }
    }

    public IEnumerable<Entry> Get(string name)
    {
        foreach (var list in _storage)
        {
            yield return (Entry)list.Value.Where(item => item.Name == name);
        }
    }

    public IEnumerable<Entry> Get(EntryType recordType)
    {
        return _storage[recordType];
    }

    public IEnumerable<Entry> Get(string name, EntryType recordType)
    {
        return _storage[recordType].Where(record => record.Name == name);
    }

    public decimal GetTotal(EntryType recordType)
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
        foreach (var type in (EntryType[])Enum.GetValues(typeof(EntryType)))
        {
            _storage[type] = [];
        }
    }
}
