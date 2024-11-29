using Course_Material.Interface.Repositories;
using Course_Material.Interface.Service;
using Course_Material.Model.Entities;
using Course_Material.Model.Exceptions;
using Course_Material.Model.RequestModel;

namespace Course_Material.Implementation.Service
{
    public class DepartmentService(IRepositoryManager repositoryManager) : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository = repositoryManager.DepartmentRepository;
        private readonly IUnitOfWork _unitOfWork = repositoryManager.UnitOfWork; 
        private readonly IFacultyRepository _facultyRepository = repositoryManager.FacultyRepository;
        public async Task<(bool success, string message)> Create(DepartmentRequest model)
        {
            var getDepartment = await _departmentRepository.GetSingle(x => x.Name == model.Name);
            if (getDepartment != null) throw new BadRequestException($"Department with the name {model.Name} already exist");

            var getFaculty = await _facultyRepository.GetSingle(x => x.Id == model.FacultyId) ?? throw new NotFoundException("Faculty not found!!!");

            Department department = new()
            {
                Name = model.Name,
                FacultyName = getFaculty.Name,
                FacultyId = getFaculty.Id,
                Faculty = getFaculty,
            };

            await _departmentRepository.Insert(department);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Department Created succesfully");
        }

        public async Task<List<GetManyDepartment>> GetAll()
        {
            var departments = await _departmentRepository.GetAll();
            if(!departments.Any()) return [];

            return departments.Select(x => new GetManyDepartment
            {
                Name = x.Name,
                FacultyName = x.FacultyName,
                FacultyId = x.FacultyId,
                Id = x.Id,
            }).ToList();
        }
    }
}
