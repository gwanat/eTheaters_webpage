using System.ComponentModel.DataAnnotations;

namespace eTheaters.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string Picture { get; set; }
        public string FullName { get; set; }   
        public string Bio { get; set; }

        public List<Actor_Play> Actors_Plays { get; set; }

    }
}
