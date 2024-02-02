using eTheaters.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTheaters.Controllers
{
    public class TheatersController : Controller
    {
        private readonly AppDbContext _context;

        public TheatersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var AllTheaters = await _context.Theaters.ToListAsync();
            return View(AllTheaters);
        }
    }
}

