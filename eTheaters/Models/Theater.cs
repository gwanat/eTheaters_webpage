using eTheaters.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTheaters.Models
{
    public class Theater:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Theater Logo")]
        [Required(ErrorMessage = "Theater logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Theater Name")]
        [Required(ErrorMessage = "Theater name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Theater description is required")]
        public string Description { get; set; }

        public List<Play>? Plays { get; set; }
    }
}
