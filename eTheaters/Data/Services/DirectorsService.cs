using eTheaters.Data.Base;
using eTheaters.Models;

namespace eTheaters.Data.Services
{
    public class DirectorsService:EntityBaseRepository<Director>, IDirectorsService
    {
        public DirectorsService(AppDbContext context) : base(context)
        {
            
        }
    }
}
