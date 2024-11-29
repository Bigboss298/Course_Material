using Course_Material.Data;
using Course_Material.Interface.Repositories;
using Course_Material.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Course_Material.Implementation.Repositories
{
    public class MaterialRepository(ApplicationDbContext context) : IMaterialRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<bool> CheckMaterials(string name)
        {
            return await _context.Materials.AnyAsync(x => x.Name == name);
        }

        public void Delete(Materials material) => _context.Materials.Remove(material);

        public void DeleteRange(List<Materials> materials) => _context.Materials.RemoveRange(materials);
       

        public async Task<List<Materials>> GetAll()
        {
           return await _context.Materials.ToListAsync();
        }

        public async Task<List<Materials>> GetMany(Expression<Func<Materials, bool>> expression)
        {
            return await _context.Materials.Where(expression).ToListAsync();
        }

        public async Task<Materials> GetSingle(Expression<Func<Materials, bool>> expression)
        {
            return await _context.Materials.FirstOrDefaultAsync(expression);
        }

        public async Task Insert(Materials material) => await _context.Materials.AddAsync(material);
       

        public async Task InsertRange(List<Materials> materials) => await _context.Materials.AddRangeAsync(materials);


        public void Update(Materials material) => _context.Materials.Update(material);
       
    }
}
