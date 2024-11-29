namespace Course_Material.Interface.Repositories
{
    public interface IRepositoryManager
    {
        IUnitOfWork UnitOfWork { get; }
        ICourseRepository CourseRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IFacultyRepository FacultyRepository { get; }
        ILecturerRepository LecturerRepository { get; }
        ILevelRepository LevelRepository { get; }
        IStudentRepository StudentRepository { get; }
        IUserRepository UserRepository { get; }
        IMaterialRepository MaterialRepository { get; }
    }
}
