using eTheaters.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTheaters.Controllers
{
    public class PlaysController : Controller
    {
        private readonly AppDbContext _context;

        public PlaysController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var AllPlays = await _context.Plays.Include(n => n.Theater).OrderBy(n => n.Name).ToListAsync();
            return View(AllPlays);
        }
    }
}
