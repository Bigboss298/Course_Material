using Course_Material.Data;
using Course_Material.Interface.Repositories;
using Course_Material.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Course_Material.Implementation.Repositories
{
    public class LevelRepository(ApplicationDbContext context) : ILevelRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> CheckLevel(string name) => await _context.Levels.AnyAsync(x => x.Name == name);
        

        public void Delete(Level level) => _context.Levels.Remove(level);   
      

        public async Task<List<Level>> GetAll()
        {
            return await _context.Levels.ToListAsync();
        }

        public async Task<List<Level>> GetMany(Expression<Func<Level, bool>> expression)
        {
            return await _context.Levels.Where(expression).ToListAsync();
        }

        public async Task<Level> GetSingle(Expression<Func<Level, bool>> expression)
        {
            return await _context.Levels.FirstOrDefaultAsync(expression);
        }

        public async Task Insert(Level level) => await _context.Levels.AddAsync(level);
        

        public void Update(Level level) => _context.Levels.Update(level);
        
    }
}
