using System;
using System.ComponentModel.DataAnnotations;

namespace FootBall.Web.Data.Entities
{
    public class GameEntity
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime GameDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime GameDateLocal => GameDate.ToLocalTime();

        public ClubEntity Local { get; set; }

        public ClubEntity Visitor { get; set; }

        [Display(Name = "Goals Local")]
        public int GoalsLocal { get; set; }

        [Display(Name = "Goals Visitor")]
        public int GoalsVisitor { get; set; }

        public ResultEntity Result { get; set; }

        [Display(Name = "Yellow Cards")]
        public int YellowCards { get; set; }

        public bool Played { get; set; }

        public SessionEntity Session { get; set; }

        public TournamentEntity Tournament { get; set; }
    }
}
