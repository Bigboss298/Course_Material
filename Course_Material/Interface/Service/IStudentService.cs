using Course_Material.Model.RequestModel;

namespace Course_Material.Interface.Service
{
    public interface IStudentService
    {
        Task<(bool success, string message)> Create(StudentAccountRequest model);

    }
}
