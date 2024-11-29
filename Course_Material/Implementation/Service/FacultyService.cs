using Course_Material.Interface.Repositories;
using Course_Material.Interface.Service;
using Course_Material.Model.Entities;
using Course_Material.Model.Exceptions;
using Course_Material.Model.RequestModel;

namespace Course_Material.Implementation.Service
{
    public class FacultyService(IRepositoryManager repositoryManager) : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository = repositoryManager.FacultyRepository;
        private readonly IUnitOfWork _unitOfWork = repositoryManager.UnitOfWork;    
        public async Task<(bool success, string message)> Create(string name)
        {
            var checkfaculty = await _facultyRepository.CheckFaculty(name);
            if (checkfaculty) throw new BadRequestException($"faculty with the name {name} already exist");

            Faculty faculty = new()
            {
                Name = name,
            };

            await _facultyRepository.Insert(faculty);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Faculty created successfully!!!");
        }

        public async Task<List<GetManyFaculty>> GetAll()
        {
            var faculties = await _facultyRepository.GetAll();
            if (!faculties.Any()) return [];

            return faculties.Select(x => new GetManyFaculty
            {
                Name = x.Name,
                Id = x.Id,
            }).ToList();
        }
    }
}
