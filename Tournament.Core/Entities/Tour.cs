using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Tournament.Core.Entities
{
    public class Tour
    {
        public int Id { get; set; }
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

            // configure max length for title
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);
            // configure data time
            builder
               .Property(t => t.StartDate)
               .HasConversion(
                   time => time.ToString("yyyy-MM-ddTHH:mm:ss"),
                   timeString => DateTime.ParseExact(timeString, "yyyy-MM-ddTHH:mm:ss", null)
               );
        }
    }
}
