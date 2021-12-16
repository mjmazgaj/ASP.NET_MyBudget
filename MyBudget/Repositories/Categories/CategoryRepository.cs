using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBudget.Models;

namespace MyBudget.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryManagerContext _context;

        public CategoryRepository(CategoryManagerContext context)
        {
            _context = context;
        }
        Category ICategoryRepository.Get(int idCat)
            => _context.Categories.SingleOrDefault(x => x.IdCat == idCat);

        IQueryable<Category> ICategoryRepository.GetAll()
        => _context.Categories;
        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        void ICategoryRepository.Update(int idCat, Category category)
        {
            var result = _context.Categories.SingleOrDefault(x => x.IdCat == idCat);
            if (result != null)
            {
                result.NameCat = category.NameCat;

                _context.SaveChanges();
            }
        }
        void ICategoryRepository.Delete(int idCat)
        {
            var result = _context.Categories.SingleOrDefault(x => x.IdCat == idCat);
            if (result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
