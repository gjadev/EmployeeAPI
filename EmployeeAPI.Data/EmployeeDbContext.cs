using EmployeeAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}