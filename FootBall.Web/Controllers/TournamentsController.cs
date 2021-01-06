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
        private readonly ICombosHelper _combosHelper;

        public TournamentsController(DataContext context, IConverterHelper converterHelper, IImageHelper imageHelper, ICombosHelper combosHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
            _combosHelper = combosHelper;
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

                TournamentEntity tournamentEntity = _converterHelper.ToTournamentEntity(model, path, false);
                _context.Update(tournamentEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournamentEntity = await _context.Tournaments.FirstOrDefaultAsync(t => t.Id == id);
            if (tournamentEntity == null)
            {
                return NotFound();
            }

            _context.Tournaments.Remove(tournamentEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournamentEntity = await _context.Tournaments
                .Include(t => t.Classifications)
                .ThenInclude(c => c.Club)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tournamentEntity == null)
            {
                return NotFound();
            }

            return View(tournamentEntity);
        }

        public async Task<IActionResult> AddClubClassification(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TournamentEntity tournamentEntity = await _context.Tournaments.FindAsync(id);
            if(tournamentEntity == null)
            {
                return NotFound();
            }

            ClassificationViewModel model = new ClassificationViewModel
            {
                Tournament = tournamentEntity,
                TournamentId = tournamentEntity.Id,
                Clubs = _combosHelper.GetComboClubs()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddClubClassification(ClassificationViewModel model)
        {
            if(ModelState.IsValid)
            {
                ClassificationEntity classificationEntity = await _converterHelper.ToClassificationEntityAsync(model, true);
                _context.Add(classificationEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.TournamentId}");
            }

            model.Tournament = await _context.Tournaments.FindAsync(model.TournamentId);
            model.Clubs = _combosHelper.GetComboClubs();
            return View(model);
        }
    }
}
