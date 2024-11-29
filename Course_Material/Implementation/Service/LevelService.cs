using Course_Material.Interface.Repositories;
using Course_Material.Interface.Service;
using Course_Material.Model.Entities;
using Course_Material.Model.Exceptions;
using Course_Material.Model.RequestModel;

namespace Course_Material.Implementation.Service
{
    public class LevelService(IRepositoryManager repositoryManager) : ILevelService
    {
        private readonly ILevelRepository _levelRepository = repositoryManager.LevelRepository;
        private readonly IUnitOfWork _unitOfWork = repositoryManager.UnitOfWork;
        public async Task<(bool success, string message)> Create(string name)
        {
            var checkLevel = await _levelRepository.CheckLevel(name);
            if (checkLevel) throw new BadRequestException($"Lvel {name}");

            Level level = new()
            {
                Name = name,
            };
            await _levelRepository.Insert(level);
            await _unitOfWork.SaveChangesAsync();
            return (true, "Level created successfully!!!");
        }
        public async Task<List<GetManyLevel>> GetAll()
        {
            var levels = await _levelRepository.GetAll();
            if (!levels.Any()) return [];

            return levels.Select(x => new GetManyLevel
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();
        }
    }
}
