namespace SalaryBudgeterConsole.Entries;

/// <summary>
/// Base class for financial objects.
/// </summary>
public class Entry
{
    public string Name { get; }
    public string Description { get; }
    public decimal[] Amounts { get; }
    public EntryType EntryType { get; }

    public readonly char? Sign;

    public decimal Amount => Amounts.Sum();


    public Entry(string name, string description, decimal[] amounts, EntryType entryType, char? sign = '$')
    {
        Name = name;
        Description = description;
        Amounts = amounts;
        EntryType = entryType;
        Sign = sign;
    }

    public Entry(string name, string description, decimal amount, EntryType entryType, char? sign = '$')
        : this(name, description, [amount], entryType, sign) { }

    public Entry(string name, string description, float amount, EntryType entryType, char? sign = '$')
        : this(name, description, [(decimal)amount], entryType, sign) { }
}
