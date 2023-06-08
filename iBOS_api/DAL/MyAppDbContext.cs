using iBOS_api.Models;
using Microsoft.EntityFrameworkCore;
namespace iBOS_api.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> tblEmployee { get; set; }
        public DbSet<EmployeeAttendance> tblEmployeeAttendance { get; set; }
    }
}
