using Course_Material.Model.Entities;
using System.Data;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Course_Material.Interface.Repositories
{
    public interface ICourseRepository
    {
        Task Insert(Course course);
        void Update(Course course);
        Task<Course> GetSingle(Expression<Func<Course, bool>> expression);
        Task<bool> CheckCourse(string name);
        Task<List<Course>> GetMany(Expression<Func<Course, bool>> expression);
        Task<List<Course>> GetAll();
        void Delete(Course course);

    }
}
