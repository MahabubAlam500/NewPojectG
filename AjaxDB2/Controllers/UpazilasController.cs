using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AjaxDB2.Models;

namespace AjaxDB2.Controllers
{
    public class UpazilasController : Controller
    {
        private readonly AjaxDB2Context _context;

        public UpazilasController(AjaxDB2Context context)
        {
            _context = context;
        }

        // GET: Upazilas
        public async Task<IActionResult> Index()
        {
            var ajaxDB2Context = _context.Upazilas.Include(u => u.District);
            return View(await ajaxDB2Context.ToListAsync());
        }

        // GET: Upazilas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upazila = await _context.Upazilas
                .Include(u => u.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upazila == null)
            {
                return NotFound();
            }

            return View(upazila);
        }

        // GET: Upazilas/Create
        public IActionResult Create()
        {
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id");
            return View();
        }

        // POST: Upazilas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DistrictId,Name")] Upazila upazila)
        {
            if (ModelState.IsValid)
            {
                _context.Add(upazila);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id", upazila.DistrictId);
            return View(upazila);
        }

        // GET: Upazilas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upazila = await _context.Upazilas.FindAsync(id);
            if (upazila == null)
            {
                return NotFound();
            }
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id", upazila.DistrictId);
            return View(upazila);
        }

        // POST: Upazilas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DistrictId,Name")] Upazila upazila)
        {
            if (id != upazila.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(upazila);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpazilaExists(upazila.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id", upazila.DistrictId);
            return View(upazila);
        }

        // GET: Upazilas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upazila = await _context.Upazilas
                .Include(u => u.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upazila == null)
            {
                return NotFound();
            }

            return View(upazila);
        }

        // POST: Upazilas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var upazila = await _context.Upazilas.FindAsync(id);
            _context.Upazilas.Remove(upazila);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UpazilaExists(int id)
        {
            return _context.Upazilas.Any(e => e.Id == id);
        }
    }
}
