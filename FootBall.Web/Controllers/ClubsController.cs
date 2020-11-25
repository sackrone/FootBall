using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootBall.Web.Data;
using FootBall.Web.Data.Entities;

namespace FootBall.Web.Controllers
{
    public class ClubsController : Controller
    {
        private readonly DataContext _context;

        public ClubsController(DataContext context)
        {
            _context = context;
        }

        // GET: Clubs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clubs.ToListAsync());
        }

        // GET: Clubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubEntity = await _context.Clubs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clubEntity == null)
            {
                return NotFound();
            }

            return View(clubEntity);
        }

        // GET: Clubs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LogoPath,LigaMX,IsActive")] ClubEntity clubEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clubEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clubEntity);
        }

        // GET: Clubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubEntity = await _context.Clubs.FindAsync(id);
            if (clubEntity == null)
            {
                return NotFound();
            }
            return View(clubEntity);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LogoPath,LigaMX,IsActive")] ClubEntity clubEntity)
        {
            if (id != clubEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clubEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubEntityExists(clubEntity.Id))
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
            return View(clubEntity);
        }

        // GET: Clubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubEntity = await _context.Clubs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clubEntity == null)
            {
                return NotFound();
            }

            return View(clubEntity);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clubEntity = await _context.Clubs.FindAsync(id);
            _context.Clubs.Remove(clubEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubEntityExists(int id)
        {
            return _context.Clubs.Any(e => e.Id == id);
        }
    }
}
