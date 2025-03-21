namespace SalaryBudgeter.Entries;

/// <summary>
/// Base class for financial objects.
/// </summary>
public class Entry
{
    public string Name { get; }
    public string Description { get; }
    public decimal[] Amounts { get; }
    public EntryType EntryType { get; }

    public decimal Amount => Amounts.Sum();
    public char Sign => EntryType == EntryType.Other ? '%' : '$';

    public Entry(string name, string description, decimal[] amounts, EntryType entryType)
    {
        Name = name;
        Description = description;
        Amounts = amounts;
        EntryType = entryType;
    }

    public Entry(string name, string description, decimal amount, EntryType entryType)
        : this(name, description, [amount], entryType) { }

    public Entry(string name, string description, float amount, EntryType entryType)
        : this(name, description, [(decimal)amount], entryType) { }
}
