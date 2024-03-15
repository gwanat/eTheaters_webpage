using eTheaters.Data;
using eTheaters.Data.Services;
using eTheaters.Data.Static;
using eTheaters.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTheaters.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class TheatersController : Controller
    {
        private readonly ITheatersService _service;

        public TheatersController(ITheatersService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllTheaters = await _service.GetAllAsync();
            return View(AllTheaters);
        }

        //GET: Theaters/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Theater theater)
        {
            if (!ModelState.IsValid) return View(theater);
            await _service.AddAsync(theater);
            return RedirectToAction(nameof(Index));
        }

        //GET: Theaters/Details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var theaterDetails = await _service.GetByIdAsync(id);
            if (theaterDetails == null) return View("NotFound");
            return View(theaterDetails);
        }

        //GET: Theaters/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var theaterDetails = await _service.GetByIdAsync(id);
            if (theaterDetails == null) return View("NotFound");
            return View(theaterDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Theater theater)
        {
            if (!ModelState.IsValid) return View(theater);
            await _service.UpdateAsync(id, theater);
            return RedirectToAction(nameof(Index));
        }

        //GET: Theaters/Delete

        public async Task<IActionResult> Delete(int id)
        {
            var theaterDetails = await _service.GetByIdAsync(id);
            if (theaterDetails == null) return View("NotFound");
            return View(theaterDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var theaterDetails = await _service.GetByIdAsync(id);
            if (theaterDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

