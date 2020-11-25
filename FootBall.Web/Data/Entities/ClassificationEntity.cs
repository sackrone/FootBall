using System.ComponentModel.DataAnnotations;

namespace FootBall.Web.Data.Entities
{
    public class ClassificationEntity
    {
        public int Id { get; set; }

        public ClubEntity Club { get; set; }

        [Display(Name = "Games Played")]
        public int GamesPlayed { get; set; }

        [Display(Name = "Games Won")]
        public int GamesWon { get; set; }

        [Display(Name = "Games Tied")]
        public int GamesTied { get; set; }

        [Display(Name = "Games Lost")]
        public int GamesLost { get; set; }

        public int Points => GamesWon * 3 + GamesTied;

        [Display(Name = "Goals For")]
        public int GoalsFor { get; set; }

        [Display(Name = "Goals Against")]
        public int GoalsAgainst { get; set; }

        [Display(Name = "Goals Difference")]
        public int GoalsDifference => GoalsFor - GoalsAgainst;

        public TournamentEntity Tournament { get; set; }
    }
}
