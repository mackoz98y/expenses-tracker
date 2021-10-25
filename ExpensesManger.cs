using System;
using System.Collections.Generic;

namespace ExpensesTracker
{
    class ExpensesManager
    {
        public List<Expense> ExpensesList { get
            {
                return _expensesList;
            }
        }

        private List<Expense> _expensesList = new List<Expense>();

        
        public void RegisterExpense(Expense expense)
        {
            _expensesList.Add(expense);
        }

        public void DisplayAllExpenses()
        {
            _expensesList.ForEach(e => Console.WriteLine(e.DisplayFormat()));
        }
    }
}
