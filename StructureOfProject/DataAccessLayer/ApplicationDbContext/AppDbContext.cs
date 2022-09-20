

using Microsoft.EntityFrameworkCore;
using StructureOfProject.Models;

namespace StructureOfProject.DataAccessLayer.ApplicationDbContext.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<People> Peoples { get; set; }
    }
}
