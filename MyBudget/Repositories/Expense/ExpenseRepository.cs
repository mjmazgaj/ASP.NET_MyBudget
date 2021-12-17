using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var expenses =_context.Expenses.Include("Category");
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

        Category IExpenseRepository.GetCategory(int idCat)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.IdCat == idCat);

            return category;
        }
    }
}

