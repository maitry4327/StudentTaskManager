using Microsoft.EntityFrameworkCore;
using StudentTaskManager.Models;

namespace StudentTaskManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment> Assignments { get; set; }
    }
}