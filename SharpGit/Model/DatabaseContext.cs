using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SharpGit.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./database.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}