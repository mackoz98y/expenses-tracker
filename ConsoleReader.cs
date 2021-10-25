using System;

namespace ExpensesTracker
{
    class ConsoleReader
    {
        public Expense CreateExpenseFromInput()
        {
            Expense expense = null;
            bool formatOk = false;
            do
            {
                try
                {
                    Console.WriteLine("Expenses name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Expenses value:  ##,##");
                    double value = double.Parse(Console.ReadLine());
                    Console.WriteLine("Type of expense:");
                    Type type = ReadType();
                    expense = new Expense(name, value, type);
                    formatOk = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid format!");
                }
            } while (!formatOk);
            return expense;
        }


        private Type ReadType()
        {
            var x = Enum.GetValues(typeof(Type));
            foreach(var s in x)
            {
                Console.WriteLine((byte)s + " - " + s);
            }
            byte val = byte.Parse(Console.ReadLine());
            if(val >= 0 && val < x.Length)
            {
                return (Type)val;
            }

            throw new FormatException();
            
        }
    }
}
