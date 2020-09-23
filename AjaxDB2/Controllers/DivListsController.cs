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
    public class DivListsController : Controller
    {
        private readonly AjaxDB2Context _context;

        public DivListsController(AjaxDB2Context context)
        {
            _context = context;
        }

        // GET: DivLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.DivLists.ToListAsync());
        }

        // GET: DivLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divList = await _context.DivLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (divList == null)
            {
                return NotFound();
            }

            return View(divList);
        }

        // GET: DivLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DivLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DivList divList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(divList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(divList);
        }

        // GET: DivLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divList = await _context.DivLists.FindAsync(id);
            if (divList == null)
            {
                return NotFound();
            }
            return View(divList);
        }

        // POST: DivLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DivList divList)
        {
            if (id != divList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(divList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivListExists(divList.Id))
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
            return View(divList);
        }

        // GET: DivLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divList = await _context.DivLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (divList == null)
            {
                return NotFound();
            }

            return View(divList);
        }

        // POST: DivLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var divList = await _context.DivLists.FindAsync(id);
            _context.DivLists.Remove(divList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DivListExists(int id)
        {
            return _context.DivLists.Any(e => e.Id == id);
        }
    }
}
