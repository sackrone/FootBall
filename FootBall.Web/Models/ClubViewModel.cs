using FootBall.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FootBall.Web.Models
{
    public class ClubViewModel : ClubEntity
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
