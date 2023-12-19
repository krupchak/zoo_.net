using Microsoft.EntityFrameworkCore;
using ZooAnimals.Models;

namespace ZooAnimals.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Animals> Animals { get; set; }
    }
}