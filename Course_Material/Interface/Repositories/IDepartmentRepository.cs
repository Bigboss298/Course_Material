using Course_Material.Model.Entities;
using System.Linq.Expressions;

namespace Course_Material.Interface.Repositories
{
    public interface IDepartmentRepository
    {
        Task Insert(Department department);
        void Update(Department department);
        Task<Department> GetSingle(Expression<Func<Department, bool>> expression);
        Task<List<Department>> GetMany(Expression<Func<Department, bool>> expression);
        Task<List<Department>> GetAll();
        void Delete(Department department);
        Task<bool> CheckDepartment(string name);

    }
}
