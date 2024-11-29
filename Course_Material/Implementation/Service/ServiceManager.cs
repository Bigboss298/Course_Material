using Course_Material.Auth;
using Course_Material.FileManager;
using Course_Material.Implementation.Repositories;
using Course_Material.Interface.Repositories;
using Course_Material.Interface.Service;

namespace Course_Material.Implementation.Service
{
    public class ServiceManager(IRepositoryManager repositoryManager, IFileManager fileManager, IConfiguration config, IJWTManager tokenService) : IServiceManager
    {
        private readonly Lazy<ICourseService> _lazyCourseService = new(() => new CourseService(repositoryManager));
        private readonly Lazy<ILecturerService> _lazyLecturerService = new(() => new LecturerService(repositoryManager, fileManager));
        private readonly Lazy<IStudentService> _lazyStudentService = new(() => new StudentService(repositoryManager, fileManager));
        private readonly Lazy<IDepartmentService> _lazyDepartment = new(() => new DepartmentService(repositoryManager));
        private readonly Lazy<IFacultyService> _lazyFacultyService = new(() => new FacultyService(repositoryManager));  
        private readonly Lazy<ILevelService> _lazyLevelService = new(() => new LevelService(repositoryManager));
        private readonly Lazy<IUserService> _lazyUserService = new(() => new UserService(repositoryManager, tokenService, config));             
        public ICourseService CourseService => _lazyCourseService.Value;

        public IDepartmentService DepartmentService => _lazyDepartment.Value;

        public IFacultyService FacultyService => _lazyFacultyService.Value;

        public ILecturerService LecturerService => _lazyLecturerService.Value;

        public ILevelService LevelService => _lazyLevelService.Value;

        public IStudentService StudentService => _lazyStudentService.Value;

        public IUserService UserService => _lazyUserService.Value;
    }
}
