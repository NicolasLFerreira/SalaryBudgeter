using Microsoft.VisualBasic;

using SalaryBudgeter.Budgeting;
using SalaryBudgeter.Records;

using System;

namespace SalaryBudgeter
{
    public class Program
    {
        static void Main(string[] args)
        {
            IFinancialRecordManager finances = new FinancialRecordManager();

            finances.AddRange([
                // Incomes
                new("Wage", "Hourly wage", 25m, FinancialRecordType.Income),
                
                // Expenses
                new("Rent", "Weekly rent", 150m, FinancialRecordType.Expense),
                new("Gas", "Weekly transport", 80m, FinancialRecordType.Expense),
                new("Food", "Weekly food", 20m, FinancialRecordType.Expense),
                new("Gym", "Weekly gym membership", 7.2m, FinancialRecordType.Expense),
                new("Other", "Weekly miscellaneous", 20m, FinancialRecordType.Expense),

                // Savings
                new ("Savings", "Money from my savings account.", 1001.38m, FinancialRecordType.Saving),
                new ("Upcoming", "Money from upcoming salary.", 1181m, FinancialRecordType.Saving),
                new ("Due Paid Leave", "Money from Mexico's due paid leave.", 1000m, FinancialRecordType.Saving)

                // Goals

            ]);

            SetInformation();
        }

        static void SetInformation()
        {
            string[] weeklyHourScheme =
           [
                "20-2 28-5 40-2 28-7 40-5", // uni
                "30-4 16-16 20-16",
                "40-2 20-2"
           ];

            int index = 0;

            List<FinancialRecord> incomes =
            [
                new("Wage", "Hourly wage", 25m, FinancialRecordType.Income)
            ];

            List<FinancialRecord> expenses =
            [
                 new("Rent", "Weekly rent", 150m, FinancialRecordType.Expense),
                 new("Gas", "Weekly transport", 80m, FinancialRecordType.Expense),
                 new("Food", "Weekly food", 20m, FinancialRecordType.Expense),
                 new("Gym", "Weekly gym membership", 7.2m, FinancialRecordType.Expense),
                 new("Other", "Weekly miscellaneous", 20m, FinancialRecordType.Expense),
            ];

            List<FinancialRecord> savings =
            [
                new ("Savings", "Money from my savings account.", 1001.38m, FinancialRecordType.Saving),
                new ("Upcoming", "Money from upcoming salary.", 1181m, FinancialRecordType.Saving),
                new ("Due Paid Leave", "Money from Mexico's due paid leave.", 1000m, FinancialRecordType.Saving)
            ];

            BudgetCalculator manager = new(incomes, expenses, savings, 19m, weeklyHourScheme[index], (7000m + (400m + 700m + 400m + 300m + 150m) + (400.24m + 96.10m + 167.50m + 75m)));

            var result = manager.Calculate();

            foreach (var item in result)
            {
                Console.WriteLine($"=> {item.Name:0.00}:");
                Console.WriteLine($"   - {item.Description:0.00}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"   - {item.Sign}{item.Amount:0.00}\n");
                Console.ResetColor();
            }
        }
    }
}
