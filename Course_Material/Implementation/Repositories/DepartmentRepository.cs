using Course_Material.Data;
using Course_Material.Interface.Repositories;
using Course_Material.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Course_Material.Implementation.Repositories
{
    public class DepartmentRepository(ApplicationDbContext context) : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> CheckDepartment(string name)
        {
            return await _context.Departments.AnyAsync(x => x.Name == name);
        }

        public void Delete(Department department) => _context.Departments.Remove(department);
       

        public async Task<List<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<List<Department>> GetMany(Expression<Func<Department, bool>> expression)
        {
           return await _context.Departments.Where(expression).ToListAsync();
        }

        public async Task<Department> GetSingle(Expression<Func<Department, bool>> expression)
        {
            return await _context.Departments.FirstOrDefaultAsync(expression);
        }

        public async Task Insert(Department department) => await _context.Departments.AddAsync(department);


        public async void Update(Department department) => _context.Departments.Update(department);
        
    }
}
