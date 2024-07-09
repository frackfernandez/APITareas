using Microsoft.EntityFrameworkCore;
using Repository.Entidades;

namespace Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskEntity> Tasks { get; set; } // tabla
    }
}
