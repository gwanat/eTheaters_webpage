using eTheaters.Models;
using System.Collections.Concurrent;

namespace eTheaters.Data.ViewModels
{
    public class NewPlayDropdownsVM
    {
        public NewPlayDropdownsVM()
        {
            Directors = new List<Director>();
            Theaters = new List<Theater>();
            Actors = new List<Actor>();
        }

        public List<Director> Directors { get; set; }
        public List<Theater> Theaters { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
