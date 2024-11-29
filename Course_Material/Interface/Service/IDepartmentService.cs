using Course_Material.Model.RequestModel;

namespace Course_Material.Interface.Service
{
    public interface IDepartmentService
    {
        Task<(bool success, string message)> Create(DepartmentRequest model);
        Task<List<GetManyDepartment>> GetAll();
    }
}
