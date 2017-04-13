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
    public class ToBeInformedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToBeInformedController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ToBeInformed
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToBeInformed.ToListAsync());
        }

        // GET: ToBeInformed/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toBeInformed = await _context.ToBeInformed
                .SingleOrDefaultAsync(m => m.Id == id);
            if (toBeInformed == null)
            {
                return NotFound();
            }

            return View(toBeInformed);
        }

        // GET: ToBeInformed/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToBeInformed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BeInformed")] ToBeInformed toBeInformed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toBeInformed);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(toBeInformed);
        }

        // GET: ToBeInformed/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toBeInformed = await _context.ToBeInformed.SingleOrDefaultAsync(m => m.Id == id);
            if (toBeInformed == null)
            {
                return NotFound();
            }
            return View(toBeInformed);
        }

        // POST: ToBeInformed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BeInformed")] ToBeInformed toBeInformed)
        {
            if (id != toBeInformed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toBeInformed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToBeInformedExists(toBeInformed.Id))
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
            return View(toBeInformed);
        }

        // GET: ToBeInformed/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toBeInformed = await _context.ToBeInformed
                .SingleOrDefaultAsync(m => m.Id == id);
            if (toBeInformed == null)
            {
                return NotFound();
            }

            return View(toBeInformed);
        }

        // POST: ToBeInformed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toBeInformed = await _context.ToBeInformed.SingleOrDefaultAsync(m => m.Id == id);
            _context.ToBeInformed.Remove(toBeInformed);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ToBeInformedExists(int id)
        {
            return _context.ToBeInformed.Any(e => e.Id == id);
        }
    }
}
