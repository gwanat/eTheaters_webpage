using eTheaters.Data.Base;
using eTheaters.Models;

namespace eTheaters.Data.Services
{
    public class TheatersService:EntityBaseRepository<Theater>, ITheatersService
    {
        public TheatersService(AppDbContext context) : base(context)
        {
            
        }
    }
}
