using Microsoft.VisualBasic;

using SalaryBudgeter.Budgeting;
using SalaryBudgeter.Entries;

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
            IEntryManager finances = new EntryManager();

            string[] weeklyHourScheme =
            [
                "20-2 28-5 40-2 28-7 40-5", // uni
                "30-4 16-16 20-16",
                "40-2 20-2"
            ];

            int index = 0;

            finances.AddRange([
                // Incomes
                new("Wage", "Hourly wage", 25m, EntryType.Income),
                
                // Expenses
                new("Rent", "Weekly rent", 150m, EntryType.Expense),
                new("Gas", "Weekly transport", 70m, EntryType.Expense),
                new("Gym", "Weekly gym membership", 7.2m, EntryType.Expense),
                new("Food", "Weekly food", 20m, EntryType.Expense),
                new("Monster", "Weekly monster cost", 13m, EntryType.Expense),
                new("Other", "Misc spendings", 20m, EntryType.Expense),

                // Savings
                new ("Savings", "Money from my savings account.", 2182.38m, EntryType.Saving),
                new ("Due Paid Leave", "Money from Mexico's due paid leave.", 1000m, EntryType.Saving),

                // Goals
                new ("Z400", "Price of the motorcycle", 6999.99m, EntryType.Goal),
                new ("Helmet", "Price of the helmet", 400m, EntryType.Goal),
                new ("Jacket", "Price of the jacket", 700m, EntryType.Goal),
                new ("Leggings", "Price of the leggings", 400m, EntryType.Goal),
                new ("Boots", "Price of the boots", 300m, EntryType.Goal),
                new ("Gloves", "Price of the gloves", 150m, EntryType.Goal),
                new ("Learner", "Price of the learner license", 90.6m, EntryType.Goal),
                new ("Restricted", "Price of the restricted license", 54.2m, EntryType.Goal),
                new ("REGO", "Price of the REGO", 424.28m, EntryType.Goal),
                new ("WOF", "Price of the WOF", 75m, EntryType.Goal),
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
