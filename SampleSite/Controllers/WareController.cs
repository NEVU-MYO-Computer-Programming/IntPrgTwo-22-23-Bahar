using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleSite.Models;

namespace SampleSite.Controllers
{
    public class WareController : Controller
    {
        private readonly SampleContext _context;

        public WareController(IConfiguration _c)
        {
            _context = new SampleContext(_c);
        }

        // GET: Ware
        public async Task<IActionResult> Index()
        {
            return _context.Wares != null ?
                        View(await _context.Wares.ToListAsync()) :
                        Problem("Entity set 'SampleContext.Wares'  is null.");
        }

        // GET: Ware/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Wares == null)
            {
                return NotFound();
            }

            var ware = await _context.Wares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ware == null)
            {
                return NotFound();
            }

            return View(ware);
        }

        // GET: Ware/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ware/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Detail")] Ware ware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ware);
        }

        // GET: Ware/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Wares == null)
            {
                return NotFound();
            }

            var ware = await _context.Wares.FindAsync(id);
            if (ware == null)
            {
                return NotFound();
            }
            return View(ware);
        }

        // POST: Ware/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Detail")] Ware ware)
        {
            if (id != ware.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ware);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WareExists(ware.Id))
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
            return View(ware);
        }

        // GET: Ware/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Wares == null)
            {
                return NotFound();
            }

            var ware = await _context.Wares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ware == null)
            {
                return NotFound();
            }

            return View(ware);
        }

        // POST: Ware/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Wares == null)
            {
                return Problem("Entity set 'SampleContext.Wares'  is null.");
            }
            var ware = await _context.Wares.FindAsync(id);
            if (ware != null)
            {
                _context.Wares.Remove(ware);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WareExists(long id)
        {
            return (_context.Wares?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        public JsonResult GetAllWares()
        {
            var allWares = _context.Wares.ToList();
            return Json(allWares);
        }



    }
}
