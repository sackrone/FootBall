using FootBall.Web.Data;
using FootBall.Web.Data.Entities;
using FootBall.Web.Helpers;
using FootBall.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FootBall.Web.Controllers
{
    public class SessionsController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public SessionsController(DataContext context, ICombosHelper combosHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Sessions.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
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

            SessionViewModel model = new SessionViewModel
            {
                Tournament = tournamentEntity,
                TournamentId = tournamentEntity.Id,
                Types = _combosHelper.GetComboTypeSession()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SessionViewModel model)
        {
            if(ModelState.IsValid)
            {
                SessionEntity sessionEntity = await _converterHelper.ToSessionEntityAsync(model, true);
                _context.Add(sessionEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction($"{nameof(Index)}/{model.TournamentId}");
            }

            model.Tournament = await _context.Tournaments.FindAsync(model.TournamentId);
            model.Types = _combosHelper.GetComboTypeSession();
            return View(model);
        }
    }
}
