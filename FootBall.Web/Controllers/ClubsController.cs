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

        public async Task<IActionResult> Index()
        {
            return View(await _context.Clubs.ToListAsync());
        }

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClubEntity clubEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clubEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"the club {clubEntity.Name} already exists");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(clubEntity);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClubEntity clubEntity)
        {
            if (id != clubEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                _context.Update(clubEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"the club {clubEntity.Name} already exists");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(clubEntity);
        }

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
