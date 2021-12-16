using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Models;
using MyBudget.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: ExpenseController
        public ActionResult Index()
        {
            
            return View(_categoryRepository.GetAll());
        }

        // GET: ExpenseController/Create
        public ActionResult Create()
        {
            return View(new Category());
        }

        // POST: ExpenseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {

            _categoryRepository.Add(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: ExpenseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_categoryRepository.Get(id));
        }

        // POST: ExpenseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            _categoryRepository.Update(id, category);
            return RedirectToAction(nameof(Index));
        }


    }
}
