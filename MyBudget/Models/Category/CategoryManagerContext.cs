using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Models
{
    public class CategoryManagerContext : DbContext
    {
        public CategoryManagerContext(DbContextOptions<CategoryManagerContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

    }
}
