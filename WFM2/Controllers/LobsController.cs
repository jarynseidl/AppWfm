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
    public class LobsController : Controller
    {
        private readonly FSREContext _context;

        public LobsController(FSREContext context)
        {
            _context = context;    
        }

        // GET: Lobs
        public async Task<IActionResult> Index()
        {
            var fSREContext = _context.Lob.Include(l => l.Dept);
            return View(await fSREContext.ToListAsync());
        }

        // GET: Lobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lob = await _context.Lob
                .Include(l => l.Dept)
                .Include(l => l.Split)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lob == null)
            {
                return NotFound();
            }

            return View(lob);
        }

        // GET: Lobs/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_context.Dept, "Id", "Name");
            return View();
        }

        // POST: Lobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeptId,Lob1,FteDefinition")] Lob lob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lob);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DeptId"] = new SelectList(_context.Dept, "Id", "Id", lob.DeptId);
            return View(lob);
        }

        // GET: Lobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lob = await _context.Lob.SingleOrDefaultAsync(m => m.Id == id);
            if (lob == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_context.Dept, "Id", "Name", lob.DeptId);
            return View(lob);
        }

        // POST: Lobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeptId,Lob1,FteDefinition")] Lob lob)
        {
            if (id != lob.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LobExists(lob.Id))
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
            ViewData["DeptId"] = new SelectList(_context.Dept, "Id", "Id", lob.DeptId);
            return View(lob);
        }

        // GET: Lobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lob = await _context.Lob
                .Include(l => l.Dept)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lob == null)
            {
                return NotFound();
            }

            return View(lob);
        }

        // POST: Lobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lob = await _context.Lob.SingleOrDefaultAsync(m => m.Id == id);
            _context.Lob.Remove(lob);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LobExists(int id)
        {
            return _context.Lob.Any(e => e.Id == id);
        }
    }
}
