using Course_Material.Model.Entities;
using Course_Material.Model.RequestModel;
using Course_Material.Model.ResponseModel;

namespace Course_Material.Interface.Service
{
    public interface IUserService
    {
        Task<BaseResponse<GetUserWithToken>> Login(string username, string password);
        Task<List<GetUser>> GetAll();
    }
}
