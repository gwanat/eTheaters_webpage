using eTheaters.Data.Base;
using eTheaters.Models;
using Microsoft.EntityFrameworkCore;

namespace eTheaters.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }
    }
}
