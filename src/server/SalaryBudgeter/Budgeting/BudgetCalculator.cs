using SalaryBudgeter.Clocking;
using SalaryBudgeter.Entries;

namespace SalaryBudgeter.Budgeting;

internal class BudgetCalculator(IEntryManager financialRecordManager, IHourScheme hourScheme,  decimal tax) : IBudgetCalculator
{
    private readonly IEntryManager _financialManager = financialRecordManager;
    private readonly IHourScheme _hourScheme = hourScheme;
    private decimal Tax { get; } = tax;

    public List<Entry> Calculate()
    {
        int weeks = 0;
        int hours = 0;

        foreach (var item in _hourScheme.Get())
        {
            weeks += item.Repeat;
            hours += item.Hours * item.Repeat;
        }

        //foreach (string scheme in WeeklyHoursScheme.Split(' '))
        //{
        //    string[] parts = scheme.Split("-");

        //    int weeklyHours = int.Parse(parts[0]);
        //    int amountWeeks = int.Parse(parts[1]);

        //    hours += weeklyHours * amountWeeks;
        //    weeks += amountWeeks;
        //}

        decimal salary = _financialManager.GetTotal(EntryType.Income) * hours * ((100 - Tax) / 100);

        decimal totalExpenses = _financialManager.GetTotal(EntryType.Expense) * weeks;

        decimal profit = salary - totalExpenses;
        decimal percentage = totalExpenses * 100 / salary;

        decimal savings = _financialManager.GetTotal(EntryType.Saving);
        decimal goal = _financialManager.GetTotal(EntryType.Goal);

        return
        [ 
            new ("Weeks", "Total weeks", (decimal)weeks, EntryType.Report, null),
            new ("Savings", "Currently saved amount.", savings, EntryType.Saving),
            new ("Salary", "Salary in time span.", salary, EntryType.Report),
            new ("Expenses", "Expenses in time span.", totalExpenses, EntryType.Report),
            new ("Goal", "Amount to be saved.", goal, EntryType.Saving),
            new ("Profit", "Salary after expenses.", salary - totalExpenses, EntryType.Report),
            new ("Final", "Profit with saved amount.", profit + savings, EntryType.Report),
            new ("Delta", "Difference from goal.", -(goal - (profit + savings)), EntryType.Report),
            new ("Ratio", "Expense % of salary.", percentage, EntryType.Report, '%'),
        ];
    }
}
