using CommandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt ) : base(opt)
        {
            
        }

        public DbSet<Animals> Animals { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Animals>()
                .HasMany(a => a.Commands)
                .WithOne(a=> a.Animal!)
                .HasForeignKey(a => a.AnimalID);

            modelBuilder
                .Entity<Command>()
                .HasOne(a => a.Animal)
                .WithMany(a => a.Commands)
                .HasForeignKey(a =>a.AnimalID);
        }
    }
}