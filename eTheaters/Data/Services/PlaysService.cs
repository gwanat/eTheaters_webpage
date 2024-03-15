using eTheaters.Data.Base;
using eTheaters.Data.ViewModels;
using eTheaters.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace eTheaters.Data.Services
{
    public class PlaysService : EntityBaseRepository<Play>, IPlaysService
    {
        private readonly AppDbContext _context;

        public PlaysService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewPlayAsync(NewPlayVM data)
        {
            var newPlay = new Play()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                TheaterId = data.TheaterId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                PlayCategory = data.PlayCategory,
                DirectorId = data.DirectorId
            };
            await _context.Plays.AddAsync(newPlay);
            await _context.SaveChangesAsync();

            //Add play actors
            foreach(var actorId in data.ActorIds)
            {
                var newActorPlay = new Actor_Play()
                {
                    PlayId = newPlay.Id,
                    ActorId = actorId
                };
                await _context.Actors_Plays.AddAsync(newActorPlay);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<NewPlayDropdownsVM> GetNewPlayDropdownsValues()
        {
            var response = new NewPlayDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Theaters = await _context.Theaters.OrderBy(n => n.Name).ToListAsync(),
                Directors = await _context.Directors.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task<Play> GetPlayByIdAsync(int id)
        {
            var playDetails = await _context.Plays
                .Include(c => c.Theater)
                .Include(d => d.Director)
                .Include(ap => ap.Actors_Plays).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return playDetails;
        }

        public async Task UpdatePlayAsync(NewPlayVM data)
        {
            var dbPlay = await _context.Plays.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbPlay != null)
            {
                dbPlay.Name = data.Name;
                dbPlay.Description = data.Description;
                dbPlay.Price = data.Price;
                dbPlay.ImageURL = data.ImageURL;
                dbPlay.TheaterId = data.TheaterId;
                dbPlay.StartDate = data.StartDate;
                dbPlay.EndDate = data.EndDate;
                dbPlay.PlayCategory = data.PlayCategory;
                dbPlay.DirectorId = data.DirectorId;
                await _context.SaveChangesAsync();
            }

            var existingActorsDb = _context.Actors_Plays.Where(n => n.PlayId == data.Id).ToList();
            _context.Actors_Plays.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add play actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorPlay = new Actor_Play()
                {
                    PlayId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Plays.AddAsync(newActorPlay);
            }
            await _context.SaveChangesAsync();
        }
    }
}
