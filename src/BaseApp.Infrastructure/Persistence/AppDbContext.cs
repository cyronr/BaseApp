using Domain.Models.ProfileModels;
using Infrastructure.Common.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    private readonly DatabaseSettings _databaseSettings;

    public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<DatabaseSettings> connectionOptions) : base(options)
    {
        _databaseSettings = connectionOptions.Value;
    }


    //Profiles
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<ProfileEvent> ProfileEvents { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_databaseSettings.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}