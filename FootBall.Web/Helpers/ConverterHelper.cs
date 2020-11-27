using FootBall.Web.Data.Entities;
using FootBall.Web.Models;

namespace FootBall.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public ClubEntity ToClubEntity(ClubViewModel model, string path, bool isNew)
        {
            return new ClubEntity
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                LogoPath = path,
                LigaMX = model.LigaMX,
                IsActive = model.IsActive
            };
        }

        public ClubViewModel ToClubViewModel(ClubEntity clubEntity)
        {
            return new ClubViewModel 
            {
                Id = clubEntity.Id,
                Name = clubEntity.Name,
                LogoPath = clubEntity.LogoPath,
                LigaMX = clubEntity.LigaMX,
                IsActive = clubEntity.IsActive
            };
        }

        public TournamentEntity ToTournamentEntity(TournamentViewModel model, string path, bool isNew)
        {
            return new TournamentEntity
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                StartDate = model.StartDate.ToUniversalTime(),
                EndDate = model.EndDate.ToUniversalTime(),
                LogoPath = path,
                IsActive = model.IsActive,
                Classifications = model.Classifications,
                Sessions = model.Sessions
            };
        }

        public TournamentViewModel ToTournamentViewModel(TournamentEntity tournamentEntity)
        {
            return new TournamentViewModel
            {
                Id = tournamentEntity.Id,
                Name = tournamentEntity.Name,
                StartDate = tournamentEntity.StartDate,
                EndDate = tournamentEntity.EndDate,
                LogoPath = tournamentEntity.LogoPath,
                IsActive = tournamentEntity.IsActive,
                Classifications = tournamentEntity.Classifications,
                Sessions = tournamentEntity.Sessions
            };
        }
    }
}
