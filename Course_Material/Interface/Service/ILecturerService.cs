using Course_Material.Model.RequestModel;

namespace Course_Material.Interface.Service
{
    public interface ILecturerService
    {
        Task<(bool success, string message)> Create(LecturerAccountRequest model);

    }
}
