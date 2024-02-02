using eTheaters.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTheaters.Models
{
    public class Director:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile picture is required.")]
        public string Picture { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 characters.")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required.")]
        public string Bio { get; set; }

        public List<Play>? Plays { get; set; }
    }
}