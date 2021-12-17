using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.Models;

namespace MyBudget.Repositories
{
    public interface IExpenseRepository
    {

        Expense Get(int idExp);
        IQueryable<Expense> GetAll();
        void Add(Expense expense);
        void Update(int idExp, Expense expense);
        void Delete(int idExp);
        List<SelectListItem> GetCategories();
        Category GetCategory(int idCat);
    }
}
