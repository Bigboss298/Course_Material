using Course_Material.Model.Entities;
using System.Linq.Expressions;

namespace Course_Material.Interface.Repositories
{
    public interface ILecturerRepository
    {
        Task Insert(Lecturer lecturer);
        void Update(Lecturer lecturer);
        Task<Lecturer> GetSingle(Expression<Func<Lecturer, bool>> expression);
        Task<List<Lecturer>> GetMany(Expression<Func<Lecturer, bool>> expression);
        Task<List<Lecturer>> GetAll();
        void Delete(Lecturer lecturer);


    }
}
