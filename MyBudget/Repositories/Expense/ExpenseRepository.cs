using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.Models;

namespace MyBudget.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseManagerContext _context;

        public ExpenseRepository(ExpenseManagerContext context)
        {
            _context = context;
        }
        
        Expense IExpenseRepository.Get(int idExp)
        => _context.Expenses.SingleOrDefault(x => x.IdExp == idExp);

        IQueryable<Expense> IExpenseRepository.GetAll()
        {
            var expenses = from exp in _context.Expenses
                           join cat in _context.Categories on exp.Category equals cat.IdCat
                           select new Expense
                           {
                               IdExp = exp.IdExp,
                               DateExp = exp.DateExp,
                               NameExp = exp.NameExp,
                               ValueExp = exp.ValueExp,
                               CategoryName = cat.NameCat,
                           };
            
            return expenses;
        }
        public void Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        void IExpenseRepository.Update(int idExp, Expense expense)
        {
            var result = _context.Expenses.SingleOrDefault(x => x.IdExp == idExp);
            if (result != null)
            {
                result.NameExp = expense.NameExp;
                result.ValueExp = expense.ValueExp;
                result.DateExp = expense.DateExp;

                _context.SaveChanges();
            }
        }
        void IExpenseRepository.Delete(int idExp)
        {
            var result = _context.Expenses.SingleOrDefault(x => x.IdExp == idExp);
            if (result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
        }

        List<SelectListItem> IExpenseRepository.GetCategories()
        {
            List<SelectListItem>  listOfCategories = (from cat in _context.Categories
                                select new SelectListItem()
                                {
                                    Text = cat.NameCat,
                                    Value = cat.IdCat.ToString()
                                }).ToList();

            return listOfCategories;
        }
    }
}

