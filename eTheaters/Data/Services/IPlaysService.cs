using eTheaters.Data.Base;
using eTheaters.Data.ViewModels;
using eTheaters.Models;

namespace eTheaters.Data.Services
{
    public interface IPlaysService : IEntityBaseRepository<Play>
    {
        Task<Play> GetPlayByIdAsync(int id);
        Task<NewPlayDropdownsVM> GetNewPlayDropdownsValues();
        Task AddNewPlayAsync(NewPlayVM data);
        Task UpdatePlayAsync(NewPlayVM data);
    }
}
