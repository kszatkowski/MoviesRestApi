using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Application.Constants;
using Movies.Application.Entities;

namespace Movies.Application.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(MovieConstraints.TitleMaxLength);

        builder.Property(m => m.YearOfRelease).IsRequired();

        builder.Property(m => m.Description)
            .HasMaxLength(MovieConstraints.DescriptionMaxLength);
    }
}