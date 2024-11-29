using Course_Material.Data;
using Course_Material.Interface.Repositories;
using Course_Material.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Course_Material.Implementation.Repositories
{
    public class LecturerRepository(ApplicationDbContext context) : ILecturerRepository
    {
        private readonly ApplicationDbContext _context = context;

        public void Delete(Lecturer lecturer) => _context.Lecturers.Remove(lecturer);
       

        public async Task<List<Lecturer>> GetAll()
        {
            return await _context.Lecturers.ToListAsync();
        }

        public async Task<List<Lecturer>> GetMany(Expression<Func<Lecturer, bool>> expression)
        {
            return await _context.Lecturers.Where(expression).ToListAsync();
        }

        public async Task<Lecturer> GetSingle(Expression<Func<Lecturer, bool>> expression)
        {
            return await _context.Lecturers.FirstOrDefaultAsync(expression);
        }

        public async Task Insert(Lecturer lecturer) => await _context.Lecturers.AddAsync(lecturer);


        public void Update(Lecturer lecturer) => _context.Lecturers.Update(lecturer);
        
    }
}
