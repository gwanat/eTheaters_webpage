using eTheaters.Data;
using eTheaters.Data.Services;
using eTheaters.Data.Static;
using eTheaters.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTheaters.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PlaysController : Controller
    {
        private readonly IPlaysService _service;

        public PlaysController(IPlaysService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllPlays = await _service.GetAllAsync(n => n.Theater);
            return View(AllPlays);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allPlays = await _service.GetAllAsync(n => n.Theater);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allPlays.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains
                    //(searchString.ToLower())).ToList();

                var filteredResultNew = allPlays.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allPlays);
        }

        //GET: Plays/Details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var playDetail = await _service.GetPlayByIdAsync(id);
            return View(playDetail);
        }

        //GET: Plays/Create
        public async Task<IActionResult> Create()
        {
            var playDropdownsData = await _service.GetNewPlayDropdownsValues();

            ViewBag.Theaters = new SelectList(playDropdownsData.Theaters, "Id", "Name");
            ViewBag.Directors = new SelectList(playDropdownsData.Directors, "Id", "FullName");
            ViewBag.Actors = new SelectList(playDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPlayVM play)
        {
            if (!ModelState.IsValid)
            {
                var playDropdownsData = await _service.GetNewPlayDropdownsValues();

                ViewBag.Theaters = new SelectList(playDropdownsData.Theaters, "Id", "Name");
                ViewBag.Directors = new SelectList(playDropdownsData.Directors, "Id", "FullName");
                ViewBag.Actors = new SelectList(playDropdownsData.Actors, "Id", "FullName");
                return View(play);
            }

            await _service.AddNewPlayAsync(play);
            return RedirectToAction(nameof(Index)); 
        }

        //GET: Plays/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var playDetails = await _service.GetPlayByIdAsync(id);
            if (playDetails == null) return View("NotFound");

            var response = new NewPlayVM()
            {
                Id = playDetails.Id,
                Name = playDetails.Name,
                Description = playDetails.Description,
                Price = playDetails.Price,
                StartDate = playDetails.StartDate,
                EndDate = playDetails.EndDate,
                ImageURL = playDetails.ImageURL,
                PlayCategory = playDetails.PlayCategory,
                TheaterId = playDetails.TheaterId,
                DirectorId = playDetails.DirectorId,
                ActorIds = playDetails.Actors_Plays.Select(n => n.ActorId).ToList(),
            };

            var playDropdownsData = await _service.GetNewPlayDropdownsValues();
            ViewBag.Theaters = new SelectList(playDropdownsData.Theaters, "Id", "Name");
            ViewBag.Directors = new SelectList(playDropdownsData.Directors, "Id", "FullName");
            ViewBag.Actors = new SelectList(playDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewPlayVM play)
        {
            if (id != play.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var playDropdownsData = await _service.GetNewPlayDropdownsValues();

                ViewBag.Theaters = new SelectList(playDropdownsData.Theaters, "Id", "Name");
                ViewBag.Directors = new SelectList(playDropdownsData.Directors, "Id", "FullName");
                ViewBag.Actors = new SelectList(playDropdownsData.Actors, "Id", "FullName");
                return View(play);
            }

            await _service.UpdatePlayAsync(play);
            return RedirectToAction(nameof(Index));
        }
    }
}
