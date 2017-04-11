using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WFM2.Data;
using WFM2.Models.WFM;

namespace WFM2.Controllers
{
    public class SplitsController : Controller
    {
        private readonly FSREContext _context;

        public SplitsController(FSREContext context)
        {
            _context = context;    
        }

        // GET: Splits
        public async Task<IActionResult> Index()
        {
            var fSREContext = _context.Split.Include(s => s.Lob).Include(s => s.Vendor);
            return View(await fSREContext.ToListAsync());
        }

        // GET: Splits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var split = await _context.Split
                .Include(s => s.Lob)
                .Include(s => s.Vendor)
                .SingleOrDefaultAsync(m => m.SplitId == id);
            if (split == null)
            {
                return NotFound();
            }

            return View(split);
        }

        // GET: Splits/Create
        public IActionResult Create()
        {
            ViewData["LobId"] = new SelectList(_context.Lob, "Id", "Lob1");
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "Vendor1");
            return View();
        }

        // POST: Splits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SplitId,VendorId,Acd,Split1,LobId")] Split split)
        {
            if (ModelState.IsValid)
            {
                _context.Add(split);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["LobId"] = new SelectList(_context.Lob, "Id", "Lob1", split.LobId);
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "Abbrev", split.VendorId);
            return View(split);
        }

        // GET: Splits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var split = await _context.Split.SingleOrDefaultAsync(m => m.SplitId == id);
            if (split == null)
            {
                return NotFound();
            }
            ViewData["LobId"] = new SelectList(_context.Lob, "Id", "Lob1", split.LobId);
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "Vendor1", split.VendorId);
            return View(split);
        }

        // POST: Splits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SplitId,VendorId,Acd,Split1,LobId")] Split split)
        {
            if (id != split.SplitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(split);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SplitExists(split.SplitId))
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
            ViewData["LobId"] = new SelectList(_context.Lob, "Id", "Lob1", split.LobId);
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "Abbrev", split.VendorId);
            return View(split);
        }

        // GET: Splits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var split = await _context.Split
                .Include(s => s.Lob)
                .Include(s => s.Vendor)
                .SingleOrDefaultAsync(m => m.SplitId == id);
            if (split == null)
            {
                return NotFound();
            }

            return View(split);
        }

        // POST: Splits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var split = await _context.Split.SingleOrDefaultAsync(m => m.SplitId == id);
            _context.Split.Remove(split);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SplitExists(int id)
        {
            return _context.Split.Any(e => e.SplitId == id);
        }
    }
}
