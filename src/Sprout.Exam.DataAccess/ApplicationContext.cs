using Microsoft.EntityFrameworkCore;
using Sprout.Exam.Common.Models.DTO;

namespace Sprout.Exam.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
