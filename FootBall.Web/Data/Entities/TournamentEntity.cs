using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootBall.Web.Data.Entities
{
    public class TournamentEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The {0} field must not be longer than {1} characters.")]
        [Required(ErrorMessage = "The {0} field is required.")]        
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime StartDateLocal => StartDate.ToLocalTime();

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime EndDateLocal => EndDate.ToLocalTime();

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public ICollection<ClassificationEntity> Classifications { get; set; }

        public ICollection<SessionEntity> Sessions { get; set; }

        public ICollection<GameEntity> Games { get; set; }
    }
}
