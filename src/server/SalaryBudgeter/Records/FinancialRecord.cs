namespace SalaryBudgeter.Records
{
    /// <summary>
    /// Base class for financial objects.
    /// </summary>
    public class FinancialRecord
    {
        public string Name { get; }
        public string Description { get; }
        public decimal[] Amounts { get; }
        public FinancialRecordType RecordType { get; }

        public decimal Amount => Amounts.Sum();
        public char Sign => RecordType == FinancialRecordType.Other ? '%' : '$';

        public FinancialRecord(string name, string description, decimal[] amounts, FinancialRecordType recordType)
        {
            Name = name;
            Description = description;
            Amounts = amounts;
            RecordType = recordType;
        }

        public FinancialRecord(string name, string description, decimal amount, FinancialRecordType recordType)
            : this(name, description, [amount], recordType) { }

        public FinancialRecord(string name, string description, float amount, FinancialRecordType recordType)
            : this(name, description, [(decimal)amount], recordType) { }
    }
}
