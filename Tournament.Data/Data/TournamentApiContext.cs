using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;

namespace Tournament.Data.Data
{
    public class TournamentApiContext : DbContext
    {
        public TournamentApiContext (DbContextOptions<TournamentApiContext> options)
            : base(options)
        {
        }

        public DbSet<Tour> Tour => Set<Tour>();
        public DbSet<Game> Game => Set<Game>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TournamentApiContext).Assembly);

        }
    }
}
