using HandySquad.Models;
using HandySquad.Models.ProfileModels;
using Microsoft.EntityFrameworkCore;

namespace HandySquad.Data;

public class DataContext : DbContext
{
    public DataContext()
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Skill> SkillSets { get; set; }
    public DbSet<ProfileImage> ProfileImages { get; set; }
    public DbSet<Deal> Deals { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(p => p.Profile)
            .WithOne(u => u.User)
            .HasForeignKey<Profile>(u => u.Id)
            .IsRequired(false);
        
        // Configure the one-to-one relationship
        modelBuilder.Entity<Profile>()
            .HasOne(p => p.ProfileImage)
            .WithOne(pi => pi.Profile)
            .HasForeignKey<ProfileImage>(pi => pi.Id);

        modelBuilder.Entity<Deal>()
            .HasOne(d => d.Artisan)
            .WithMany()
            .HasForeignKey(d=>d.ArtisanId);
        modelBuilder.Entity<Deal>()
            .HasOne(d => d.Client)
            .WithMany()
            .HasForeignKey(d => d.ClientId);
    }
    
}