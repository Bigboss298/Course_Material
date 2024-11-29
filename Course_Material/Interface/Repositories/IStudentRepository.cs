using Course_Material.Model.Entities;
using System.Linq.Expressions;

namespace Course_Material.Interface.Repositories
{
    public interface IStudentRepository
    {
        Task Insert(Student level);
        void Update(Student level);
        Task<Student> GetSingle(Expression<Func<Student, bool>> expression);
        Task<List<Student>> GetMany(Expression<Func<Student, bool>> expression);
        Task<List<Student>> GetAll();
        void Delete(Student student);

    }
}
