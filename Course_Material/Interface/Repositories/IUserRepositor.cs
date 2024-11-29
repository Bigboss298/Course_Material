using Course_Material.Model.Entities;
using System.Linq.Expressions;

namespace Course_Material.Interface.Repositories
{
    public interface IUserRepository
    {
        Task Insert(User user);
        void Update(User user);
        Task<User> GetSingle(Expression<Func<User, bool>> expression);
        Task<List<User>> GetMany(Expression<Func<User, bool>> expression);
        Task<List<User>> GetAll();
        Task<User> LoginAsync(string username, string password);
        void Delete(User user);
        Task<bool> CheckUser(string email);
        Task<bool> CheckUserName(string username);
    }
}
