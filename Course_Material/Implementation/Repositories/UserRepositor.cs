using Course_Material.Data;
using Course_Material.Interface.Repositories;
using Course_Material.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Course_Material.Implementation.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> CheckUser(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> CheckUserName(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public void Delete(User user) => _context.Users.Remove(user);


        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> GetMany(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.Where(expression).ToListAsync();    
        }

        public async Task<User> GetSingle(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.FirstOrDefaultAsync(expression);
        }

        public async Task Insert(User user) => await _context.Users.AddAsync(user);

        public async Task<User> LoginAsync(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password); 
        }

        public void Update(User user) => _context.Users.Update(user);   
        
    }
}
