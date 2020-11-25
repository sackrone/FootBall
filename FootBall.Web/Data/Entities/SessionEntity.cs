using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootBall.Web.Data.Entities
{
    public class SessionEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Limit Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime LimitDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Limit Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime LimitDateLocal => LimitDate.ToLocalTime();

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public TournamentEntity Tournament { get; set; }

        public ICollection<GameEntity> Games { get; set; }
    }
}
