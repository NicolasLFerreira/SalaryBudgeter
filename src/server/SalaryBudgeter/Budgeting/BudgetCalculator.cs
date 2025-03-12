using SalaryBudgeter.Records;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryBudgeter.Budgeting
{
    public class BudgetCalculator : IBudgetCalculator
    {
        public decimal TotalIncomes => Wages.Sum(wage => wage.Amount);
        public decimal TotalExpenses => Expenses.Sum(expense => expense.Amount);
        public decimal TotalSavings => Savings.Sum(saving => saving.Amount);

        private List<FinancialRecord> Wages { get; }
        private List<FinancialRecord> Expenses { get; }
        private List<FinancialRecord> Savings { get; }
        private string WeeklyHoursScheme { get; }
        private decimal Tax { get; }
        private decimal Goal { get; }

        public BudgetCalculator(List<FinancialRecord> incomes, List<FinancialRecord> expenses, List<FinancialRecord> savings, decimal tax, string weeklyHoursScheme, decimal goal)
        {
            Wages = incomes;
            Expenses = expenses;
            Savings = savings;
            WeeklyHoursScheme = weeklyHoursScheme;
            Tax = tax;
            Goal = goal;
        }

        public decimal CalculateExpenses()
        {
            return Wages.Sum(income => income.Amount);
        }

        public decimal CalculateIncomes()
        {
            return Wages.Sum(income => income.Amount);
        }

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

            decimal salary = Wages.Sum(income => income.Amount) * hours * ((100 - Tax) / 100);
            decimal totalExpenses = Expenses.Sum(expense => expense.Amount) * weeks;

            decimal profit = salary - totalExpenses;
            decimal percentage = totalExpenses * 100 / salary;

            return
            [
                new ("Weeks", "Total weeks", weeks, FinancialRecordType.Other),
                new ("Salary", "Total salary in the given time span.", salary, FinancialRecordType.Income),
                new ("Expenses", "Total expenses in the given time span.", totalExpenses, FinancialRecordType.Expense),
                new ("Profit", "Left over from salary after expenses.", salary - totalExpenses, FinancialRecordType.Income),
                new ("Ratio", "Ratio between income and expenses.", percentage, FinancialRecordType.Other),
                new ("Savings", "Amount that was already saved.", TotalSavings, FinancialRecordType.Saving),
                new ("Final", "Total amount of money in the end.", profit + TotalSavings, FinancialRecordType.Saving),
                new ("Goal", "Goal savings", Goal, FinancialRecordType.Saving),
                new ("Until Goal", "Missing amount", Goal - (profit + TotalSavings), FinancialRecordType.Saving)
            ];
        }
    }
}
