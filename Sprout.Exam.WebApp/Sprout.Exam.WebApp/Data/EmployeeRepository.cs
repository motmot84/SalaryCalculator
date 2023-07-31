using Microsoft.EntityFrameworkCore;
using Sprout.Exam.Common.Models.DTO;
using Sprout.Exam.DataAccess.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Data
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SproutExamDbContext context) 
            : base(context)
        {
            
        }
        public async Task<Employee> Create(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Delete(Employee entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(); 
            return entity;
        }

        public async Task<IEnumerable<Employee>> GetAll() => await _context.Employees.Where(e => e.IsDeleted == false).ToListAsync();

        public async Task<Employee> GetById(int id) => await _context.Employees.FindAsync(id);

        public async Task<Employee> Update(Employee entity)
        {
            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
