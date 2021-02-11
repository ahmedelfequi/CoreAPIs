using Microsoft.EntityFrameworkCore;

namespace WebGraduationProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base (options) 
        {
            
        }

        public DbSet<Product> products { get; set; }
    }
}