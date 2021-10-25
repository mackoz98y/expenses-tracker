using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.Json.Serialization;

namespace ExpensesTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            logic.ControlLoop();
            
            

        }
    }

    class Logic 
    {
        ConsoleReader reader = new ConsoleReader();
        ExpensesManager manager;
        public void ControlLoop()
        {
            GenerateFile();

            ConsoleKey key;
            manager = ImportData();
            do
            {
                DisplayOptions();
                key = Console.ReadKey().Key;

                
                switch (key)
                {
                    case ConsoleKey.X:
                        ExportData(manager);
                        break;
                    case ConsoleKey.R:
                        
                        RegisterExpense();
                        break;
                    case ConsoleKey.D:
                        DisplayExpenses();
                        break;
                }
            } while (key != ConsoleKey.X);
        }

        private void RegisterExpense()
        {
            Console.WriteLine("\n");
            Expense expense = reader.CreateExpenseFromInput();
            manager.RegisterExpense(expense);
        }

        private void DisplayExpenses()
        {
            Console.WriteLine("\n");
            manager.DisplayAllExpenses();
        }

        private void DisplayOptions()
        {
            Console.WriteLine("Press:");
            Console.WriteLine("x - exit");
            Console.WriteLine("r - register expense");
            Console.WriteLine("d - display all expenses");
        }

        private void GenerateFile()
        {
            string path = @"C:\expenses\expenses.json";
            string dirPath = @"C:\expenses";
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(dirPath);
                File.Create(path);
            }
        }

        private void ExportData(ExpensesManager manager)
        {
            string path = @"C:\expenses\expenses.json";
            var serializedData = JsonConvert.SerializeObject(manager);
            Console.WriteLine(serializedData);
            File.WriteAllText(path, serializedData);
        }

        private ExpensesManager ImportData()
        {
            string path = @"C:\expenses\expenses.json";
            var content = File.ReadAllText(path);
            if (content != string.Empty)
            {
                var x = JsonConvert.DeserializeObject<ExpensesManager>(content);
                return x;
            }
            else
            {
                return new ExpensesManager();
            }
        }
    }

}
