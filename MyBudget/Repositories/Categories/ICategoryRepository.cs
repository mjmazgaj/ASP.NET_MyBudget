using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBudget.Models;

namespace MyBudget.Repositories
{
    public interface ICategoryRepository
    {
        Category Get(int idCat);
        IQueryable<Category> GetAll();
        void Add(Category category);
        void Update(int idCat, Category category);
        void Delete(int idCat);
    }
}
