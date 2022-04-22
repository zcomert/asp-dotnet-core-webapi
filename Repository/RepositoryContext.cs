using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}