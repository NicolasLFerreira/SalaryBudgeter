using SalaryBudgeterConsole.Budgeting;
using SalaryBudgeterConsole.Clocking;
using SalaryBudgeterConsole.Entries;

namespace SalaryBudgeterConsole
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
            IHourScheme hourScheme = new HourScheme([]);

            //s1p1
            hourScheme.Add(27, 1);
            hourScheme.Add(26, 4);

            //s1b
            hourScheme.Add(40, 2);

            //s1p2
            hourScheme.Add(26, 7);
            hourScheme.Add(20, 1);

            //s1-s2
            hourScheme.Add(40, 5);

            //s1p1/2
            hourScheme.Add(20, 2);

            // finance entries
            finances.AddRange([
                // Incomes
                new("Wage", "Hourly wage", 25m, EntryType.Income),
                
                // Expenses
                new("Rent", "Weekly rent", 150m, EntryType.Expense),
                new("Gas Commute", "Commute to work", 50m, EntryType.Expense),
                new("Gas Random", "Gas for other uses", 20m, EntryType.Expense),
                new("Gym", "Weekly gym membership", 7.2m, EntryType.Expense),
                new("Monster", "Weekly monster cost", 20m, EntryType.Expense),
                new("Other", "Misc spendings", 40m, EntryType.Expense),

                // Savings
                new ("Savings", "Money from my savings account.", 2182.38m, EntryType.Saving),
                new ("Due Paid Leave", "Money from Mexico's due paid leave.", 1000m, EntryType.Saving),

                // Goals
                new ("Z400", "Motorcycle", 6500m, EntryType.Goal),
                new ("HJC i71 SizeXL", "Helmet", 430m, EntryType.Goal),
                new ("Avro 5 Sizew50", "Jacket", 499m, EntryType.Goal),
                new ("Undecided Jeans Leggings", "Leggings", 299m, EntryType.Goal),
                new ("Alpinestars Radon Drystar", "Boots", 399m, EntryType.Goal),
                new ("Alpinestars SP-2 v3", "Gloves", 239.9m, EntryType.Goal),
                new ("BHST", "Basic Handling Skill Test", 180m, EntryType.Goal),
                new ("Learner", "Learner License", 90.6m, EntryType.Goal),
                new ("Restricted", "Restricted License", 54.2m, EntryType.Goal),
                new ("REGO", "REGO", 424.28m, EntryType.Goal),
                new ("WOF", "WOF", 75m, EntryType.Goal),
            ]);

            BudgetCalculator manager = new(finances, hourScheme, 19m);

            var result = manager.Calculate();

            // Generate report
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
