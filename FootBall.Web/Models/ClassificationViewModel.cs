using FootBall.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootBall.Web.Models
{
    public class ClassificationViewModel : ClassificationEntity
    {
        public int TournamentId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [Display(Name = "Club")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a team.")]
        public int ClubId { get; set; }

        public IEnumerable<SelectListItem> Clubs { get; set; }
    }
}
