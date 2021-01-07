using FootBall.Web.Data;
using FootBall.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FootBall.Web.Controllers
{
    public class SessionsController : Controller
    {
        private readonly DataContext _context;

        public SessionsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Sessions.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SessionEntity sessionEntity)
        {
            if(ModelState.IsValid)
            {

            }

            return View(sessionEntity);
        }
    }
}
