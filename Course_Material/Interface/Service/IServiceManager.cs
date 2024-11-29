using Course_Material.Interface.Repositories;

namespace Course_Material.Interface.Service
{
    public interface IServiceManager
    {
        ICourseService CourseService { get; }
        IDepartmentService DepartmentService { get; }
        IFacultyService FacultyService { get; }
        ILecturerService LecturerService { get; }
        ILevelService LevelService { get; }
        IStudentService StudentService { get; }
        IUserService UserService { get; }
    }
}
