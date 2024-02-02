using eTheaters.Data;
using eTheaters.Data.Services;
using eTheaters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTheaters.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly IDirectorsService _service;

        public DirectorsController(IDirectorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var AllDirectors = await _service.GetAllAsync();
            return View(AllDirectors);
        }

        //GET: Directors/Details
        public async Task<IActionResult> Details(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);
            if (directorDetails == null) return View("NotFound");
            return View(directorDetails);
        }

        //GET: Directors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,Picture,Bio")]Director director)
        {
            if(!ModelState.IsValid)
            {
                return View(director);
            }
            await _service.AddAsync(director);
            return RedirectToAction(nameof(Index));
        }

        //GET: Directors/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);
            if (directorDetails == null) return View("NotFound");
            return View(directorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Picture,Bio")] Director director)
        {

            if (!ModelState.IsValid) return View(director);
            if (id == director.Id)
            {
                await _service.UpdateAsync(id, director);
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        //GET: Directors/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);
            if (directorDetails == null) return View("NotFound");
            return View(directorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);
            if (directorDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
