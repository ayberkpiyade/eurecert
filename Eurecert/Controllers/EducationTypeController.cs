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
    public class EducationTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducationTypeController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: EducationType
        public async Task<IActionResult> Index()
        {
            return View(await _context.EducationTypes.ToListAsync());
        }

        // GET: EducationType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationType = await _context.EducationTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (educationType == null)
            {
                return NotFound();
            }

            return View(educationType);
        }

        // GET: EducationType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] EducationType educationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(educationType);
        }

        // GET: EducationType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationType = await _context.EducationTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (educationType == null)
            {
                return NotFound();
            }
            return View(educationType);
        }

        // POST: EducationType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] EducationType educationType)
        {
            if (id != educationType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationTypeExists(educationType.Id))
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
            return View(educationType);
        }

        // GET: EducationType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationType = await _context.EducationTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (educationType == null)
            {
                return NotFound();
            }

            return View(educationType);
        }

        // POST: EducationType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationType = await _context.EducationTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.EducationTypes.Remove(educationType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EducationTypeExists(int id)
        {
            return _context.EducationTypes.Any(e => e.Id == id);
        }
    }
}
