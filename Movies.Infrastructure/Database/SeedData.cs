using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;

namespace Movies.Infrastructure.Database;

public static class SeedData
{
    public static void SeedGenres(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre() { Id = Guid.Parse("c2f54e31-f790-4192-85ad-21ce154b2731"), Title = "Action" },
            new Genre() { Id = Guid.Parse("78dd3d3a-361d-4e7c-91ac-df0b6cbdbbd7"), Title = "Adventure" },
            new Genre() { Id = Guid.Parse("d72c8397-de4c-4a48-bc5d-02fd87d72f6e"), Title = "Animation" },
            new Genre() { Id = Guid.Parse("edc4e41b-39ee-4162-a650-faa8022938a1"), Title = "Biography" },
            new Genre() { Id = Guid.Parse("6742e068-7729-465a-befe-6d3e76efa9fc"), Title = "Comedy" },
            new Genre() { Id = Guid.Parse("e913cfee-92a8-4586-9e49-9cd7af8d71b6"), Title = "Crime" },
            new Genre() { Id = Guid.Parse("10d1b4cf-732e-47f4-a548-60bbeee9aeb4"), Title = "Documentary" },
            new Genre() { Id = Guid.Parse("f86cb42e-3a99-4238-be25-72fec73afd18"), Title = "Drama" },
            new Genre() { Id = Guid.Parse("03b6508c-e52a-48e7-a9f4-f7dee2b311f1"), Title = "Family" },
            new Genre() { Id = Guid.Parse("e1452955-8ad1-422b-b3ac-04a7eb2c8595"), Title = "Fantasy" },
            new Genre() { Id = Guid.Parse("a3056e90-e607-4d80-b79a-be4a303fb750"), Title = "History" },
            new Genre() { Id = Guid.Parse("8a1705a0-c107-42b3-a4b6-ff7af8971d04"), Title = "Horror" },
            new Genre() { Id = Guid.Parse("4d05fb9f-a205-4b16-a1c5-fd0e198652f5"), Title = "Musical" },
            new Genre() { Id = Guid.Parse("c0b896ec-9d08-4e37-8319-7408d946635e"), Title = "Mystery" },
            new Genre() { Id = Guid.Parse("9fc1f505-aa85-49c2-ae4e-f2616b47f294"), Title = "Romance" },
            new Genre() { Id = Guid.Parse("4c4ccd31-16b4-4922-b0ed-f5481bd813f7"), Title = "Sci-Fi" },
            new Genre() { Id = Guid.Parse("c249776f-64a6-44c5-9780-24bd5222094e"), Title = "Sport" },
            new Genre() { Id = Guid.Parse("9ceed180-37b2-4de7-be74-baf0675100ad"), Title = "War" },
            new Genre() { Id = Guid.Parse("80a1db55-0d24-4eb5-a5d5-27361bcb6039"), Title = "Thriller" },
            new Genre() { Id = Guid.Parse("a4254d6b-7e05-4834-ba64-1f0aab18baca"), Title = "Western" }
        );
    }
}