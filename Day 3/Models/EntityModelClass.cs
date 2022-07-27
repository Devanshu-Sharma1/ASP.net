using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EName { get; set; }
        public string  Job { get; set; }
        public string Sal { get; set; }
        public string email { get; set; }
    }

    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
         : base(options)
        {

        }
    }
}