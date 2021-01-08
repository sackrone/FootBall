using FootBall.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootBall.Web.Models
{
    public class SessionViewModel : SessionEntity
    {
        public int TournamentId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [Display(Name = "Session")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a type.")]
        public int TypeSessionId { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; }
    }
}
