using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountManager.Data;
using AccountManager.Data.Models;
using AccountManager.Data.DataServices;
using AccountManager.Data.Models.DTO;

namespace AccountManager.UI.Controllers
{
    public class AccountTypesController : Controller
    {
        private readonly AccountTypeDataService _context;

        public AccountTypesController(AccountTypeDataService context)
        {
            _context = context;
        }

        // GET: AccountTypes
        public IActionResult Index()
        {
            return View(_context.GeTAll<AccountTypeDTO>());
        }

        // GET: AccountTypes/Details/5
        public IActionResult Details(int id)
        {


            var accountType = _context.GetById<AccountTypeDTO>(id, "Accounts");
            if (accountType == null)
            {
                return NotFound();
            }

            return View(accountType);
        }

        // GET: AccountTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Code,Name,Id")] AccountTypeDTO accountType)
        {
            if (ModelState.IsValid)
            {
                _context.Save(accountType);
                return RedirectToAction(nameof(Index));
            }
            return View(accountType);
        }

        // GET: AccountTypes/Edit/5
        public IActionResult Edit(int id)
        {

            var accountType = _context.GetById<AccountTypeDTO>(id);
            if (accountType == null)
            {
                return NotFound();
            }
            return View(accountType);
        }

        // POST: AccountTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Code,Name,Id")] AccountTypeDTO accountType)
        {
            if (id != accountType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Save(accountType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(accountType);
        }

        // GET: AccountTypes/Delete/5
        public IActionResult Delete(int id)
        {

            var accountType = _context.GetById<AccountTypeDTO>(id);
            if (accountType == null)
            {
                return NotFound();
            }
            return View(accountType);
        }

        // POST: AccountTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
