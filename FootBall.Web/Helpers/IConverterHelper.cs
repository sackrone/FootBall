using FootBall.Web.Data.Entities;
using FootBall.Web.Models;
using System.Threading.Tasks;

namespace FootBall.Web.Helpers
{
    public interface IConverterHelper
    {
        ClubEntity ToClubEntity(ClubViewModel model, string path, bool isNew);

        ClubViewModel ToClubViewModel(ClubEntity clubEntity);

        TournamentEntity ToTournamentEntity(TournamentViewModel model, string path, bool isNew);

        TournamentViewModel ToTournamentViewModel(TournamentEntity tournamentEntity);

        Task<ClassificationEntity> ToClassificationEntityAsync(ClassificationViewModel model, bool isNew);

        ClassificationViewModel ToClassificationViewModel(ClassificationEntity classificationEntity);
    }
}
