namespace SalaryBudgeter.Entries;

/// <summary>
/// Abstracts access to a storage of financial records
/// </summary>
public interface IEntryManager
{
    void Add(Entry record);
    void AddRange(IEnumerable<Entry> records);
    IEnumerable<Entry> Get(string name);
    IEnumerable<Entry> Get(EntryType recordType);
    IEnumerable<Entry> Get(string name, EntryType recordType);
    decimal GetTotal(EntryType recordType);
    // void Remove(Guid id); // Will be implemented once id system has been put in place.
    void Clear();
}