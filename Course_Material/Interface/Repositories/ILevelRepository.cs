using Course_Material.Model.Entities;
using System.Linq.Expressions;

namespace Course_Material.Interface.Repositories
{
    public interface ILevelRepository
    {
        Task Insert(Level level);
        void Update(Level level);
        Task<Level> GetSingle(Expression<Func<Level, bool>> expression);
        Task<List<Level>> GetMany(Expression<Func<Level, bool>> expression);
        Task<List<Level>> GetAll();
        void Delete(Level level);
        Task<bool> CheckLevel(string name);

    }
}
