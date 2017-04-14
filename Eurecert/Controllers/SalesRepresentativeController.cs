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
    public class SalesRepresentativeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesRepresentativeController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: SalesRepresentative
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesRepresentatives.ToListAsync());
        }

        // GET: SalesRepresentative/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesRepresentative = await _context.SalesRepresentatives
                .SingleOrDefaultAsync(m => m.Id == id);
            if (salesRepresentative == null)
            {
                return NotFound();
            }

            return View(salesRepresentative);
        }

        // GET: SalesRepresentative/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesRepresentative/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Phone,Email")] SalesRepresentative salesRepresentative)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesRepresentative);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(salesRepresentative);
        }

        // GET: SalesRepresentative/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesRepresentative = await _context.SalesRepresentatives.SingleOrDefaultAsync(m => m.Id == id);
            if (salesRepresentative == null)
            {
                return NotFound();
            }
            return View(salesRepresentative);
        }

        // POST: SalesRepresentative/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Phone,Email")] SalesRepresentative salesRepresentative)
        {
            if (id != salesRepresentative.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesRepresentative);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesRepresentativeExists(salesRepresentative.Id))
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
            return View(salesRepresentative);
        }

        // GET: SalesRepresentative/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesRepresentative = await _context.SalesRepresentatives
                .SingleOrDefaultAsync(m => m.Id == id);
            if (salesRepresentative == null)
            {
                return NotFound();
            }

            return View(salesRepresentative);
        }

        // POST: SalesRepresentative/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesRepresentative = await _context.SalesRepresentatives.SingleOrDefaultAsync(m => m.Id == id);
            _context.SalesRepresentatives.Remove(salesRepresentative);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SalesRepresentativeExists(int id)
        {
            return _context.SalesRepresentatives.Any(e => e.Id == id);
        }
    }
}
