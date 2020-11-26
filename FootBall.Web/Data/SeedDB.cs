using FootBall.Web.Data.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBall.Web.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;

        public SeedDB(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckClubsAsync();
            await CheckResultsAsync();
            await CheckTournamentsAsync();
        }

        private async Task CheckClubsAsync()
        {
            if (!_context.Clubs.Any())
            {
                AddClub("America", true, true);
                AddClub("Atlas", true, true);
                AddClub("Chivas", true, true);
                AddClub("Cruz Azul", true, true);
                AddClub("Juarez", true, true);
                AddClub("Leon", true, true);
                AddClub("Mazatlan", true, true);
                AddClub("Monterrey", true, true);
                AddClub("Necaxa", true, true);
                AddClub("Pachuca", true, true);
                AddClub("Puebla", true, true);
                AddClub("Pumas", true, true);
                AddClub("Queretaro", true, true);
                AddClub("San Luis", true, true);
                AddClub("Santos", true, true);
                AddClub("Tigres", true, true);
                AddClub("Toluca", true, true);
                AddClub("Xolos", true, true);
                await _context.SaveChangesAsync();
            }
        }

        private void AddClub(string name, bool ligaMX, bool isActive)
        {
            _context.Clubs.Add(new ClubEntity
            {
                Name = name,
                LogoPath = $"~/images/Clubs/{name}.png",
                LigaMX = ligaMX,
                IsActive = isActive
            });
        }

        private async Task CheckResultsAsync()
        {
            if (!_context.Results.Any())
            { 
                _context.Results.Add(new ResultEntity { Name = "Local" });
                _context.Results.Add(new ResultEntity { Name = "Tie" });
                _context.Results.Add(new ResultEntity { Name = "Vistor" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckTournamentsAsync()
        {
            if (!_context.Tournaments.Any())
            {
                var startDate = new DateTime(2020, 7, 24).ToUniversalTime();
                var endDate = new DateTime(2020, 11, 29).ToUniversalTime();

                _context.Tournaments.Add(new TournamentEntity
                {
                    Name = "Quiniela GS20",
                    StartDate = startDate,
                    EndDate = endDate,
                    LogoPath = $"~/images/Tournaments/Guard1anes.png",
                    IsActive = true,
                    Classifications = new List<ClassificationEntity>
                    {
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "America") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Atlas") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Chivas") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Cruz Azul") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Juarez") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Leon") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Mazatlan") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Monterrey") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Necaxa") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Pachuca") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Puebla") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Pumas") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Queretaro") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "San Luis") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Santos") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Tigres") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Toluca") },
                        new ClassificationEntity { Club = _context.Clubs.FirstOrDefault(c => c.Name == "Xolos") },
                    },
                    Sessions = new List<SessionEntity>
                    {
                        new SessionEntity
                        {
                            Name = "Jornada 1",
                            LimitDate = endDate,
                            IsActive = true,
                            Games = new List<GameEntity>
                            {
                                new GameEntity
                                {
                                    GameDate = new DateTime(2020, 7, 24, 19, 30, 0).ToUniversalTime(),
                                    Local = _context.Clubs.FirstOrDefault(t => t.Name == "Necaxa"),
                                    Visitor = _context.Clubs.FirstOrDefault(t => t.Name == "Tigres"),
                                    Played = false
                                },
                                new GameEntity
                                {
                                    GameDate = new DateTime(2020, 7, 25, 19, 0, 0).ToUniversalTime(),
                                    Local = _context.Clubs.FirstOrDefault(t => t.Name == "Chivas"),
                                    Visitor = _context.Clubs.FirstOrDefault(t => t.Name == "Leon"),
                                    Played = false
                                },
                                new GameEntity
                                {
                                    GameDate = new DateTime(2020, 7, 25, 21, 0, 0).ToUniversalTime(),
                                    Local = _context.Clubs.FirstOrDefault(t => t.Name == "Cruz Azul"),
                                    Visitor = _context.Clubs.FirstOrDefault(t => t.Name == "Santos"),
                                    Played = false
                                },
                                new GameEntity
                                {
                                    GameDate = new DateTime(2020, 7, 25, 21, 0, 0).ToUniversalTime(),
                                    Local = _context.Clubs.FirstOrDefault(t => t.Name == "Xolos"),
                                    Visitor = _context.Clubs.FirstOrDefault(t => t.Name == "Atlas"),
                                    Played = false
                                },
                                new GameEntity
                                {
                                    GameDate = new DateTime(2020, 7, 26, 12, 0, 0).ToUniversalTime(),
                                    Local = _context.Clubs.FirstOrDefault(t => t.Name == "Pumas"),
                                    Visitor = _context.Clubs.FirstOrDefault(t => t.Name == "Queretaro"),
                                    Played = false
                                },
                                new GameEntity
                                {
                                    GameDate = new DateTime(2020, 7, 27, 18, 0, 0).ToUniversalTime(),
                                    Local = _context.Clubs.FirstOrDefault(t => t.Name == "San Luis"),
                                    Visitor = _context.Clubs.FirstOrDefault(t => t.Name == "Juarez"),
                                    Played = false
                                },
                                new GameEntity
                                {
                                    GameDate = new DateTime(2020, 7, 27, 20, 0, 0).ToUniversalTime(),
                                    Local = _context.Clubs.FirstOrDefault(t => t.Name == "Pachuca"),
                                    Visitor = _context.Clubs.FirstOrDefault(t => t.Name == "America"),
                                    Played = false
                                },
                                new GameEntity
                                {
                                    GameDate = new DateTime(2020, 7, 27, 22, 0, 0).ToUniversalTime(),
                                    Local = _context.Clubs.FirstOrDefault(t => t.Name == "Mazatlan"),
                                    Visitor = _context.Clubs.FirstOrDefault(t => t.Name == "Puebla"),
                                    Played = false
                                },
                                new GameEntity
                                {
                                    GameDate = new DateTime(2020, 7, 28, 19, 0, 0).ToUniversalTime(),
                                    Local = _context.Clubs.FirstOrDefault(t => t.Name == "Monterrey"),
                                    Visitor = _context.Clubs.FirstOrDefault(t => t.Name == "Toluca"),
                                    Played = false
                                }
                            }
                        }
                    },
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}
