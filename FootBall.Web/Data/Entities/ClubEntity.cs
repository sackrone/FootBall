using System.ComponentModel.DataAnnotations;

namespace FootBall.Web.Data.Entities
{
    public class ClubEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(50, ErrorMessage = "The {0} field must not be longer than {1} characters.")]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }

        [Display(Name = "Liga MX")]
        public bool LigaMX { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
