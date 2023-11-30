using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Tournament.Core.Entities
{
    public class Tour
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }


        // nav
        public ICollection<Game>? Games { get; set; } = null;
    }

    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            // Configure primary key
            builder.HasKey(t => t.Id);

            // Configure max length for title
            builder.Property(t => t.Title)
                // Optional: .IsRequired() // Remove this line if Title is optional
                .HasMaxLength(50);

            // Configure date time conversion
            builder
                .Property(t => t.StartDate)
                .HasConversion(
                    time => time.ToString("O"), // Standard round-trip DateTime format
                    timeString => DateTime.ParseExact(timeString, "O", null)
                );
        }
    }

}
