using eTheaters.Data.Base;
using eTheaters.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTheaters.Models
{
    public class NewPlayVM
    {
        public int Id { get; set; }

        [Display(Name = "Play name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Display(Name = "Play description")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Display(Name = "Price in PLN")]
        [Required(ErrorMessage = "Price is required.")]
        public double Price { get; set; }

        [Display(Name = "Play poster URL")]
        [Required(ErrorMessage = "Play poster URL is required.")]
        public string ImageURL { get; set; }

        [Display(Name = "Play start date")]
        [Required(ErrorMessage = "Start date of the play is required.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Play end date")]
        [Required(ErrorMessage = "End date of the play is required.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Category of the play is required.")]
        public PlayCategory PlayCategory { get; set; }

        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Play actor(s) required.")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select a theater")]
        [Required(ErrorMessage = "Theater is required.")]
        public int TheaterId { get; set; }

        [Display(Name = "Select a director")]
        [Required(ErrorMessage = "Play director is required.")]
        public int DirectorId { get; set; }
    }
} 