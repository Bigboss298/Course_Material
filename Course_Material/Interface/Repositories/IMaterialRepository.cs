using Course_Material.Model.Entities;
using System.Linq.Expressions;

namespace Course_Material.Interface.Repositories
{
    public interface IMaterialRepository
    {
        Task Insert(Materials material);
        Task InsertRange(List<Materials> materials);
        void Update(Materials material);
        Task<Materials> GetSingle(Expression<Func<Materials, bool>> expression);
        Task<bool> CheckMaterials(string code);
        Task<List<Materials>> GetMany(Expression<Func<Materials, bool>> expression);
        Task<List<Materials>> GetAll();
        void Delete(Materials material);
        void DeleteRange(List<Materials> materials);
    }
}
