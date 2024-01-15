using System.ComponentModel.DataAnnotations;

namespace eTheaters.Models
{
    public class Theater
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Play> Plays { get; set; }
    }
}
