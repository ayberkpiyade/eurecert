using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eurecert.Data;
using Eurecert.Models;

namespace Eurecert.Controllers
{
    public class InstitutionalFunctionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstitutionalFunctionController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: InstitutionalFunction
        public async Task<IActionResult> Index()
        {
            return View(await _context.InstitutionalFunctions.ToListAsync());
        }

        // GET: InstitutionalFunction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutionalFunction = await _context.InstitutionalFunctions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (institutionalFunction == null)
            {
                return NotFound();
            }

            return View(institutionalFunction);
        }

        // GET: InstitutionalFunction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstitutionalFunction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FunctionCode,FunctionName")] InstitutionalFunction institutionalFunction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institutionalFunction);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(institutionalFunction);
        }

        // GET: InstitutionalFunction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutionalFunction = await _context.InstitutionalFunctions.SingleOrDefaultAsync(m => m.Id == id);
            if (institutionalFunction == null)
            {
                return NotFound();
            }
            return View(institutionalFunction);
        }

        // POST: InstitutionalFunction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FunctionCode,FunctionName")] InstitutionalFunction institutionalFunction)
        {
            if (id != institutionalFunction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institutionalFunction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionalFunctionExists(institutionalFunction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(institutionalFunction);
        }

        // GET: InstitutionalFunction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutionalFunction = await _context.InstitutionalFunctions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (institutionalFunction == null)
            {
                return NotFound();
            }

            return View(institutionalFunction);
        }

        // POST: InstitutionalFunction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institutionalFunction = await _context.InstitutionalFunctions.SingleOrDefaultAsync(m => m.Id == id);
            _context.InstitutionalFunctions.Remove(institutionalFunction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InstitutionalFunctionExists(int id)
        {
            return _context.InstitutionalFunctions.Any(e => e.Id == id);
        }
    }
}
