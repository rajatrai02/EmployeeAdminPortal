using Microsoft.EntityFrameworkCore;
using EmployeeAdminPortal.Models.Entities; // added this namespace to fetch the employee models

namespace EmployeeAdminPortal.Data
{
    public class AppDbContext: DbContext // inherits from DB context class comes from Microsoft.EntityFrameworkCore
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // generate the constructor and created a parameter with type <AppDbContext>
        {
        }

        public DbSet<Employee> Employees { get; set; } // this is to set the property and type and the name which is employees
        
    }
}
