using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Models
{
    public class ExpenseManagerContext : DbContext
    {
        public ExpenseManagerContext(DbContextOptions<ExpenseManagerContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
