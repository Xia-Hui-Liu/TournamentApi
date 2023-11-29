using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;

namespace Tournament.Data.Data
{
    public class SeedData
    {
        private static TournamentApiContext db = null!;

        public static async Task InitAsync(TournamentApiContext context)
        {
            db = context ?? throw new ArgumentNullException(nameof(context));

            if (await db.Tour.AnyAsync()) return;

            var tournaments = GenerateTournaments(5);
            await db.Tour.AddRangeAsync(tournaments);
            await db.SaveChangesAsync();
        }

        public static IEnumerable<Tour> GenerateTournaments(int nrOfTournaments)
        {
            var faker = new Faker<Tour>()
                .RuleFor(t => t.Title, f => f.Random.Word())
                .RuleFor(t => t.StartDate, f => f.Date.Past())
                .RuleFor(t => t.Games, f => GenerateGames(f.Random.Int(min: 2, max: 10)));

            return faker.Generate(nrOfTournaments);
        }

        public static List<Game> GenerateGames(int nrOfGames)
        {
            var faker = new Faker<Game>()
                .RuleFor(g => g.Title, f => f.Random.Word())
                .RuleFor(g => g.Time, f => f.Date.Past()); // Use f.Date.Past() to generate a past date

            return faker.Generate(nrOfGames).ToList();
        }
    }
}
