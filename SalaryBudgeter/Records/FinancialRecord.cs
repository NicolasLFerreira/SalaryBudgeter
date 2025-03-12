namespace SalaryBudgeter.Records
{
    /// <summary>
    /// Base class for financial objects
    /// </summary>
    public class FinancialRecord
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public FinancialRecordType RecordType { get; set; }
        public char Sign => RecordType == FinancialRecordType.Percentage ? '%' : '$';

        public FinancialRecord(string name, string description, decimal amount, FinancialRecordType recordType = FinancialRecordType.Income)
        {
            Name = name;
            Description = description;
            Amount = amount;
            RecordType = recordType;
        }
    }
}
