using FootBall.Web.Data;
using FootBall.Web.Data.Entities;
using FootBall.Web.Models;
using System.Threading.Tasks;

namespace FootBall.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

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

        public async Task<ClassificationEntity> ToClassificationEntityAsync(ClassificationViewModel model, bool isNew)
        {
            return new ClassificationEntity
            {
                Id = isNew ? 0 : model.Id,
                Club = await _context.Clubs.FindAsync(model.ClubId),
                GamesPlayed = model.GamesPlayed,
                GamesWon = model.GamesWon,
                GamesTied = model.GamesTied,
                GamesLost = model.GamesLost,
                GoalsFor = model.GoalsFor,
                GoalsAgainst = model.GoalsAgainst,
                Tournament = await _context.Tournaments.FindAsync(model.TournamentId)
            };
        }

        public ClassificationViewModel ToClassificationViewModel(ClassificationEntity classificationEntity)
        {
            return new ClassificationViewModel
            {
                Id = classificationEntity.Id,
                Club = classificationEntity.Club,
                ClubId = classificationEntity.Club.Id,
                GamesPlayed = classificationEntity.GamesPlayed,
                GamesWon = classificationEntity.GamesWon,
                GamesTied = classificationEntity.GamesTied,
                GamesLost = classificationEntity.GamesLost,
                GoalsFor = classificationEntity.GoalsFor,
                GoalsAgainst = classificationEntity.GoalsAgainst,
                Tournament = classificationEntity.Tournament,
                TournamentId = classificationEntity.Tournament.Id,
                Clubs = _combosHelper.GetComboClubs()
            };
        }
    }
}
