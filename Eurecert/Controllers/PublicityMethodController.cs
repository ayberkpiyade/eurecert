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
    public class PublicityMethodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicityMethodController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PublicityMethod
        public async Task<IActionResult> Index()
        {
            return View(await _context.PublicityMethod.ToListAsync());
        }

        // GET: PublicityMethod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicityMethod = await _context.PublicityMethod
                .SingleOrDefaultAsync(m => m.Id == id);
            if (publicityMethod == null)
            {
                return NotFound();
            }

            return View(publicityMethod);
        }

        // GET: PublicityMethod/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PublicityMethod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PublicityMethod publicityMethod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicityMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(publicityMethod);
        }

        // GET: PublicityMethod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicityMethod = await _context.PublicityMethod.SingleOrDefaultAsync(m => m.Id == id);
            if (publicityMethod == null)
            {
                return NotFound();
            }
            return View(publicityMethod);
        }

        // POST: PublicityMethod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PublicityMethod publicityMethod)
        {
            if (id != publicityMethod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicityMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicityMethodExists(publicityMethod.Id))
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
            return View(publicityMethod);
        }

        // GET: PublicityMethod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicityMethod = await _context.PublicityMethod
                .SingleOrDefaultAsync(m => m.Id == id);
            if (publicityMethod == null)
            {
                return NotFound();
            }

            return View(publicityMethod);
        }

        // POST: PublicityMethod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicityMethod = await _context.PublicityMethod.SingleOrDefaultAsync(m => m.Id == id);
            _context.PublicityMethod.Remove(publicityMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PublicityMethodExists(int id)
        {
            return _context.PublicityMethod.Any(e => e.Id == id);
        }
    }
}
