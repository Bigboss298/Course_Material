using Course_Material.Data;
using Course_Material.Interface.Repositories;
using Course_Material.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Course_Material.Implementation.Repositories
{
    public class CourseRepository(ApplicationDbContext context) : ICourseRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> CheckCourse(string code)
        {
            return await _context.Courses.AnyAsync(c => c.Code == code);
        }

        public void Delete(Course course) => _context.Courses.Remove(course);   
        

        public async Task<List<Course>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<List<Course>> GetMany(Expression<Func<Course, bool>> expression)
        {
            return await _context.Courses.Where(expression).ToListAsync();
        }

        public async Task<Course> GetSingle(Expression<Func<Course, bool>> expression)
        {
            return await _context.Courses
                .Include(x => x.Materials)
                .FirstOrDefaultAsync(expression);
        }

        public async Task Insert(Course course) => await _context.Courses.AddAsync(course);


        public void Update(Course course) => _context.Courses.Update(course);
        
    }
}
