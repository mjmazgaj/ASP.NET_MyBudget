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
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        // GET: ExpenseController
        public ActionResult Index()
        {
            return View(_expenseRepository.GetAll());
        }

        // GET: ExpenseController/Details/5
        public ActionResult Details(int id)
        {
            return View(_expenseRepository.Get(id));
        }

        // GET: ExpenseController/Create
        public ActionResult Create()
        {
            ViewData["Categories"] = _expenseRepository.GetCategories();
            return View(new Expense());
        }

        // POST: ExpenseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense expense)
        {
            var idCat = Convert.ToInt32(Request.Form["Categories"]);
            expense.IdCat = idCat;
            expense.Category = _expenseRepository.GetCategory(idCat);

            _expenseRepository.Add(expense);
            return RedirectToAction(nameof(Index));
        }

        // GET: ExpenseController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["Categories"] = _expenseRepository.GetCategories();
            return View(_expenseRepository.Get(id));
        }

        // POST: ExpenseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Expense expense)
        {
            var idCat = Convert.ToInt32(Request.Form["Categories"]);
            expense.IdCat = idCat;
            expense.Category = _expenseRepository.GetCategory(idCat);

            _expenseRepository.Update(id, expense);
            return RedirectToAction(nameof(Index));
        }

        // GET: ExpenseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_expenseRepository.Get(id));
        }

        // POST: ExpenseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Expense expense)
        {
            _expenseRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
