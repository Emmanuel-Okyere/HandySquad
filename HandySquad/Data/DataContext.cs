using HandySquad.Models;
using Microsoft.EntityFrameworkCore;

namespace HandySquad.Data;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<ProfileImage> ProfileImages { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}