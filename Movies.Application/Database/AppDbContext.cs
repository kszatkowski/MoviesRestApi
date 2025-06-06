using Microsoft.EntityFrameworkCore;
using Movies.Application.Configurations;
using Movies.Application.Entities;

namespace Movies.Application.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
    }
    
    public DbSet<Movie> Movies { get; set; }
}