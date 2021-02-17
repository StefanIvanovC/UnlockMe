using System.ComponentModel.DataAnnotations;

namespace UnlockMe.Web.ViewModels
{
    public class ProfileViewModel
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Description { get; set; }

        public int Age { get; set; }

    }
}
