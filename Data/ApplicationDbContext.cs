using quanly.Models;
using Microsoft.EntityFrameworkCore;

namespace quanly.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
        public DbSet<Student>? Students { get;}
    }
}
