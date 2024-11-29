using Course_Material.Model.RequestModel;

namespace Course_Material.Interface.Service
{
    public interface ILevelService
    {
        Task<(bool success, string message)> Create(string name);
        Task<List<GetManyLevel>> GetAll();
    }
}
