using Course_Material.Data;
using Course_Material.Interface.Repositories;

namespace Course_Material.Implementation.Repositories
{
    public class RepositoryManager(ApplicationDbContext context) : IRepositoryManager
    {
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork = new(() => new UnitOfWork(context));
        private readonly Lazy<ICourseRepository> _lazyCourseRepoitory = new(() => new CourseRepository(context));
        private readonly Lazy<IDepartmentRepository> _lazyDepartmentRepository = new(() => new DepartmentRepository(context));
        private readonly Lazy<IFacultyRepository> _lazyFacultyRepository = new(() => new FacultyRepository(context));
        private readonly Lazy<ILecturerRepository> _lazyLecturerRepository = new(() => new LecturerRepository(context));
        private readonly Lazy<ILevelRepository> _lazyLevelRepository = new(() => new LevelRepository(context));
        private readonly Lazy<IStudentRepository> _lazyStudentRepository = new(() => new StudentRepository(context));   
        private readonly Lazy<IUserRepository> _lazyUserRepository = new(() => new UserRepository(context));
        private readonly Lazy<IMaterialRepository> _lazyMaterialRepository = new(() => new MaterialRepository(context));

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

        public ICourseRepository CourseRepository => _lazyCourseRepoitory.Value;

        public IDepartmentRepository DepartmentRepository => _lazyDepartmentRepository.Value;

        public IFacultyRepository FacultyRepository => _lazyFacultyRepository.Value;

        public ILecturerRepository LecturerRepository => _lazyLecturerRepository.Value;

        public ILevelRepository LevelRepository => _lazyLevelRepository.Value;

        public IStudentRepository StudentRepository => _lazyStudentRepository.Value;

        public IUserRepository UserRepository => _lazyUserRepository.Value;

        public IMaterialRepository MaterialRepository => _lazyMaterialRepository.Value;
    }
}
