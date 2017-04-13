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
    public class ReferenceMethodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReferenceMethodController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ReferenceMethod
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReferenceMethod.ToListAsync());
        }

        // GET: ReferenceMethod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referenceMethod = await _context.ReferenceMethod
                .SingleOrDefaultAsync(m => m.Id == id);
            if (referenceMethod == null)
            {
                return NotFound();
            }

            return View(referenceMethod);
        }

        // GET: ReferenceMethod/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReferenceMethod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ReferenceMethod referenceMethod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referenceMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(referenceMethod);
        }

        // GET: ReferenceMethod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referenceMethod = await _context.ReferenceMethod.SingleOrDefaultAsync(m => m.Id == id);
            if (referenceMethod == null)
            {
                return NotFound();
            }
            return View(referenceMethod);
        }

        // POST: ReferenceMethod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ReferenceMethod referenceMethod)
        {
            if (id != referenceMethod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referenceMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenceMethodExists(referenceMethod.Id))
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
            return View(referenceMethod);
        }

        // GET: ReferenceMethod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referenceMethod = await _context.ReferenceMethod
                .SingleOrDefaultAsync(m => m.Id == id);
            if (referenceMethod == null)
            {
                return NotFound();
            }

            return View(referenceMethod);
        }

        // POST: ReferenceMethod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referenceMethod = await _context.ReferenceMethod.SingleOrDefaultAsync(m => m.Id == id);
            _context.ReferenceMethod.Remove(referenceMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReferenceMethodExists(int id)
        {
            return _context.ReferenceMethod.Any(e => e.Id == id);
        }
    }
}
