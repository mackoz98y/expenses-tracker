using System;

namespace ExpensesTracker
{
    class Expense
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Type TypeOfExpense  { get; set; }

        public Expense(string name, double value, Type type)
        {
            Name = name;
            Value = value;
            Date = DateTime.Now;
            TypeOfExpense = type;
        }

        public string DisplayFormat()
        {
            return Date.ToString("dd/MM/yyyy") + " " + Name + ": " + Value + " " + TypeOfExpense;
        }
    }
}
