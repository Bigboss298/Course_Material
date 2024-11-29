using Course_Material.Model.RequestModel;
using Course_Material.Model.ResponseModel;

namespace Course_Material.Interface.Service
{
    public interface ICourseService
    {
        Task<(bool success, string message)> Create(CourseRequest courseRequest);
        Task<(bool success, string message)> Update(CourseUpdate courseUpdate);
        Task<(bool success, string message)> Delete(string id);
        Task<GetSingleCourse> GetSingle(string id);
        Task<List<GetManyCourses>> GetMany(string param);
        Task<List<GetManyCourses>> GetAll();
    }
}
