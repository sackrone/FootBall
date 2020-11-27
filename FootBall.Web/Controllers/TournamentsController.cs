using FootBall.Web.Data;
using FootBall.Web.Data.Entities;
using FootBall.Web.Helpers;
using FootBall.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FootBall.Web.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public TournamentsController(DataContext context, IConverterHelper converterHelper, IImageHelper imageHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context
                .Tournaments
                .Include(t => t.Sessions)
                .OrderBy(t => t.StartDate)
                .ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TournamentViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;
                if (model.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsyc(model.LogoFile, "Tournaments");
                }

                TournamentEntity tournament = _converterHelper.ToTournamentEntity(model, path, true);
                _context.Add(tournament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TournamentEntity tournamentEntity = await _context.Tournaments.FindAsync(id);
            if (tournamentEntity == null)
            {
                return NotFound();
            }

            TournamentViewModel model = _converterHelper.ToTournamentViewModel(tournamentEntity);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TournamentViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = model.LogoPath;
                if (model.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsyc(model.LogoFile, "Tournaments");
                }

                TournamentEntity tournament = _converterHelper.ToTournamentEntity(model, path, false);
                _context.Add(tournament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
