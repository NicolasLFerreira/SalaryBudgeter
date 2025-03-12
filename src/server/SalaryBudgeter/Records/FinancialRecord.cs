namespace SalaryBudgeter.Records
{
    /// <summary>
    /// Base class for financial objects.
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Description"></param>
    /// <param name="Amount"></param>
    /// <param name="RecordType"></param>
    public record FinancialRecord(string Name, string Description, decimal Amount, FinancialRecordType RecordType)
    {
        public char Sign => RecordType == FinancialRecordType.Percentage ? '%' : '$';
    }
}
