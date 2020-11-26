using FootBall.Web.Data;
using FootBall.Web.Data.Entities;
using FootBall.Web.Helpers;
using FootBall.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FootBall.Web.Controllers
{
    public class ClubsController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public ClubsController(DataContext context, IImageHelper imageHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
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

            ClubEntity clubEntity = await _context.Clubs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clubEntity == null)
            {
                return NotFound();
            }

            return View(clubEntity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClubViewModel clubViewModel)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;
                if (clubViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsyc(clubViewModel.LogoFile, "Clubs");
                }

                ClubEntity clubEntity = _converterHelper.ToClubEntity(clubViewModel, path, true);
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
            return View(clubViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClubEntity clubEntity = await _context.Clubs.FindAsync(id);
            if (clubEntity == null)
            {
                return NotFound();
            }

            ClubViewModel clubViewModel = _converterHelper.ToClubViewModel(clubEntity);
            return View(clubViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClubViewModel clubViewModel)
        {
            if (id != clubViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string path = clubViewModel.LogoPath;
                if (clubViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsyc(clubViewModel.LogoFile, "Clubs");
                }

                ClubEntity clubEntity = _converterHelper.ToClubEntity(clubViewModel, path, false);
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
            return View(clubViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClubEntity clubEntity = await _context.Clubs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clubEntity == null)
            {
                return NotFound();
            }

            _context.Clubs.Remove(clubEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
