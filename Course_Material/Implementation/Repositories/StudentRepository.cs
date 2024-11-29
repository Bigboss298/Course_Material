using Course_Material.Data;
using Course_Material.Interface.Repositories;
using Course_Material.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Course_Material.Implementation.Repositories
{
    public class StudentRepository(ApplicationDbContext context) : IStudentRepository
    {
        private readonly ApplicationDbContext _context = context;

        public void Delete(Student student) => _context.Students.Remove(student);   
       

        public async Task<List<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<List<Student>> GetMany(Expression<Func<Student, bool>> expression)
        {
            return await _context.Students.Where(expression).ToListAsync();
        }

        public async Task<Student> GetSingle(Expression<Func<Student, bool>> expression)
        {
            return await _context.Students.FirstOrDefaultAsync(expression);
        }

        public async Task Insert(Student student) => await _context.Students.AddAsync(student);
        

        public void Update(Student student) => _context.Students.Update(student);
       
    }
}
