using SalaryBudgeter.Entries;

namespace SalaryBudgeter.Budgeting;

public class BudgetCalculator(IEntryManager financialRecordManager, string weeklyHoursScheme, decimal tax) : IBudgetCalculator
{
    private readonly IEntryManager _financialManager = financialRecordManager;
    private string WeeklyHoursScheme { get; } = weeklyHoursScheme;
    private decimal Tax { get; } = tax;

    public List<Entry> Calculate()
    {
        int weeks = 0;
        int hours = 0;

        foreach (string scheme in WeeklyHoursScheme.Split(' '))
        {
            string[] parts = scheme.Split("-");

            int weeklyHours = int.Parse(parts[0]);
            int amountWeeks = int.Parse(parts[1]);

            hours += weeklyHours * amountWeeks;
            weeks += amountWeeks;
        }

        decimal salary = _financialManager.GetTotal(EntryType.Income) * hours * ((100 - Tax) / 100);

        decimal totalExpenses = _financialManager.GetTotal(EntryType.Expense) * weeks;

        decimal profit = salary - totalExpenses;
        decimal percentage = totalExpenses * 100 / salary;

        decimal savings = _financialManager.GetTotal(EntryType.Saving);
        decimal goal = _financialManager.GetTotal(EntryType.Goal);

        return
        [
            new ("Weeks", "Total weeks", (decimal)weeks, EntryType.Other),
            new ("Salary", "Total salary in the given time span.", salary, EntryType.Income),
            new ("Expenses", "Total expenses in the given time span.", totalExpenses, EntryType.Expense),
            new ("Profit", "Left over from salary after expenses.", salary - totalExpenses, EntryType.Income),
            new ("Ratio", "Ratio between income and expenses.", percentage, EntryType.Other),
            new ("Savings", "Amount that was already saved.", savings, EntryType.Saving),
            new ("Final", "Total amount of money in the end.", profit + savings, EntryType.Saving),
            new ("Goal", "Goal savings", goal, EntryType.Saving),
            new ("Until Goal", "Difference to goal", -(goal - (profit + savings)), EntryType.Saving)
        ];
    }
}
