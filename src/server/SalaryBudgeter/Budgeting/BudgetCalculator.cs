using SalaryBudgeter.Records;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SalaryBudgeter.Budgeting
{
    public class BudgetCalculator(IFinancialRecordManager financialRecordManager, string weeklyHoursScheme, decimal tax) : IBudgetCalculator
    {
        private readonly IFinancialRecordManager _financialManager = financialRecordManager;
        private string WeeklyHoursScheme { get; } = weeklyHoursScheme;
        private decimal Tax { get; } = tax;

        public List<FinancialRecord> Calculate()
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

            decimal salary = _financialManager.GetTotal(FinancialRecordType.Income) * hours * ((100 - Tax) / 100);

            decimal totalExpenses = _financialManager.GetTotal(FinancialRecordType.Expense) * weeks;

            decimal profit = salary - totalExpenses;
            decimal percentage = totalExpenses * 100 / salary;

            decimal savings = _financialManager.GetTotal(FinancialRecordType.Saving);
            decimal goal = _financialManager.GetTotal(FinancialRecordType.Goal);

            return
            [
                new ("Weeks", "Total weeks", (decimal)weeks, FinancialRecordType.Other),
                new ("Salary", "Total salary in the given time span.", salary, FinancialRecordType.Income),
                new ("Expenses", "Total expenses in the given time span.", totalExpenses, FinancialRecordType.Expense),
                new ("Profit", "Left over from salary after expenses.", salary - totalExpenses, FinancialRecordType.Income),
                new ("Ratio", "Ratio between income and expenses.", percentage, FinancialRecordType.Other),
                new ("Savings", "Amount that was already saved.", savings, FinancialRecordType.Saving),
                new ("Final", "Total amount of money in the end.", profit + savings, FinancialRecordType.Saving),
                new ("Goal", "Goal savings", goal, FinancialRecordType.Saving),
                new ("Until Goal", "Missing amount", goal - (profit + savings), FinancialRecordType.Saving)
            ];
        }
    }
}
