using Course_Material.Model.RequestModel;

namespace Course_Material.Interface.Service
{
    public interface IFacultyService
    {
        Task<(bool success, string message)> Create(string name);
        Task<List<GetManyFaculty>> GetAll();
    }
}
