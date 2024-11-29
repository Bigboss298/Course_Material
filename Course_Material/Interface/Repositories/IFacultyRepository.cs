using Course_Material.Model.Entities;
using System.Linq.Expressions;

namespace Course_Material.Interface.Repositories
{
    public interface IFacultyRepository
    {
        Task Insert(Faculty faculty);
        void Update(Faculty faculty);
        Task<Faculty> GetSingle(Expression<Func<Faculty, bool>> expression);
        Task<List<Faculty>> GetMany(Expression<Func<Faculty, bool>> expression);
        Task<List<Faculty>> GetAll();
        void Delete(Faculty faculty);
        Task<bool> CheckFaculty(string name);


    }
}
