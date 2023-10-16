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
   // public DbSet<Occupation> Occupations { get; set; }
    public DbSet<SkillSet> SkillSets { get; set; }
    public DbSet<ProfileImage> ProfileImages { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("DataSource=handysquad.db");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //A Profile should have one Occupation
        // modelBuilder.Entity<Profile>()
        //     .HasMany(p => p.Occupations)
        //     .WithOne(o => o.Profile)
        //     .HasForeignKey(o => o.ProfileId);
        //
        //A Profile can have many skillsets
        modelBuilder.Entity<Profile>()
            .HasMany(p => p.SkillSets)
            .WithOne(s => s.Profile)
            .HasForeignKey(s => s.ProfileId);
        
        //A profile ahs one user
        modelBuilder.Entity<Profile>()
            .HasOne(p => p.User)
            .WithOne(u => u.Profile)
            .HasForeignKey<User>(u => u.ProfileId);
        
        // Configure the one-to-one relationship
        modelBuilder.Entity<Profile>()
            .HasOne(p => p.ProfileImage)
            .WithOne(pi => pi.Profile)
            .HasForeignKey<ProfileImage>(pi => pi.ProfileId);
    }
    
}