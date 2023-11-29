﻿
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Tournament.Core.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime Time { get; set; }

        // FK
        public int? TourId { get; set; }


    }

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            // Configure primary key
            builder.HasKey(g => g.Id);

            // configure max length for title
            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(50);

            // configure date time
            builder
               .Property(g => g.Time)
               .HasConversion(
                   time => time.ToString("yyyy-MM-ddTHH:mm:ss"),
                   timeString => DateTime.ParseExact(timeString, "yyyy-MM-ddTHH:mm:ss", null)
               ); ;
        }
    }
}
