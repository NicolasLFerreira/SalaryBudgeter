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
            Run();
        }

        static void Run()
        {
            IFinancialRecordManager finances = new FinancialRecordManager();

            string[] weeklyHourScheme =
            [
                "20-2 28-5 40-2 28-7 40-5", // uni
                "30-4 16-16 20-16",
                "40-2 20-2"
            ];

            int index = 0;

            finances.AddRange([
                // Incomes
                new("Wage", "Hourly wage", 25m, FinancialRecordType.Income),
                
                // Expenses
                new("Rent", "Weekly rent", 150m, FinancialRecordType.Expense),
                new("Gas", "Weekly transport", 70m, FinancialRecordType.Expense),
                new("Gym", "Weekly gym membership", 7.2m, FinancialRecordType.Expense),
                new("Food", "Weekly food", 20m, FinancialRecordType.Expense),
                new("Monster", "Weekly monster cost", 13m, FinancialRecordType.Expense),
                new("Other", "Misc spendings", 20m, FinancialRecordType.Expense),

                // Savings
                new ("Savings", "Money from my savings account.", 2182.38m, FinancialRecordType.Saving),
                new ("Due Paid Leave", "Money from Mexico's due paid leave.", 1000m, FinancialRecordType.Saving),

                // Goals
                new ("Z400", "Price of the motorcycle", 6999.99m, FinancialRecordType.Goal),
                new ("Helmet", "Price of the helmet", 400m, FinancialRecordType.Goal),
                new ("Jacket", "Price of the jacket", 700m, FinancialRecordType.Goal),
                new ("Leggings", "Price of the leggings", 400m, FinancialRecordType.Goal),
                new ("Boots", "Price of the boots", 300m, FinancialRecordType.Goal),
                new ("Gloves", "Price of the gloves", 150m, FinancialRecordType.Goal),
                new ("Learner", "Price of the learner license", 90.6m, FinancialRecordType.Goal),
                new ("Restricted", "Price of the restricted license", 54.2m, FinancialRecordType.Goal),
                new ("REGO", "Price of the REGO", 424.28m, FinancialRecordType.Goal),
                new ("WOF", "Price of the WOF", 75m, FinancialRecordType.Goal),
            ]);

            BudgetCalculator manager = new(finances, weeklyHourScheme[index], 19m);

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
