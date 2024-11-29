using Course_Material.Data;
using Course_Material.Interface.Repositories;
using Course_Material.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Course_Material.Implementation.Repositories
{
    public class FacultyRepository(ApplicationDbContext context) : IFacultyRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> CheckFaculty(string name)
        {
            return await _context.Faculties.AnyAsync(f => f.Name == name);  
        }

        public void Delete(Faculty faculty) => _context.Faculties.Remove(faculty);
        

        public async Task<List<Faculty>> GetAll()
        {
            return await _context.Faculties.ToListAsync();
        }

        public async Task<List<Faculty>> GetMany(Expression<Func<Faculty, bool>> expression)
        {
            return await _context.Faculties.Where(expression).ToListAsync();
        }

        public async Task<Faculty> GetSingle(Expression<Func<Faculty, bool>> expression)
        {
            return await _context.Faculties.FirstOrDefaultAsync(expression);
        }

        public async Task Insert(Faculty faculty) => await _context.Faculties.AddAsync(faculty);


        public async void Update(Faculty faculty) => _context.Faculties.Update(faculty);
      
    }
}
