using Microsoft.EntityFrameworkCore;
using AIProcessingService.Models;

namespace AIProcessingService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CVVectorData> CVVectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }
    }
}
