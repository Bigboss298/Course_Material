using Course_Material.Data;
using Course_Material.FileManager;
using Course_Material.Interface.Repositories;
using Course_Material.Interface.Service;
using Course_Material.Model.Entities;
using Course_Material.Model.Enums;
using Course_Material.Model.Exceptions;
using Course_Material.Model.RequestModel;

namespace Course_Material.Implementation.Service
{
    public class StudentService(IRepositoryManager repositoryManager, IFileManager fileManager) : IStudentService
    {
        private readonly IStudentRepository _studentRepository = repositoryManager.StudentRepository;
        private readonly IUserRepository _userRepository = repositoryManager.UserRepository;
        private readonly IDepartmentRepository _departmentRepository = repositoryManager.DepartmentRepository;
        private readonly ILevelRepository _levelRepository = repositoryManager.LevelRepository;
        private readonly IFileManager _fileManager = fileManager;
        private readonly IUnitOfWork _unitOfWork = repositoryManager.UnitOfWork;
        public async Task<(bool success, string message)> Create(StudentAccountRequest model)
        {
            var checkUser = await _userRepository.CheckUser(model.Email);
            if (checkUser) throw new BadRequestException($"A user already registered with the email :{model.Email}");

            var checkUserName = await _userRepository.CheckUserName(model.Username);
            if (checkUserName) throw new BadRequestException($"The user name {model.Username} has been choseen");

            var getDepartment = await _departmentRepository.GetSingle(x => x.Id == model.DepartmentId) ?? throw new BadRequestException("Department doesn't exist");

            var getLevel = await _levelRepository.GetSingle(x => x.Id == model.LevelId) ?? throw new BadRequestException("Level doesn't exist");

            var (success, message, filename) = await _fileManager.UploadProfilePicture(model.ProfilePicture);
            if (!success) throw new BadRequestException(message);

            User user = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Username = model.Username,
                Password = model.Password,
                Gender = (Gender)model.Gender,
                Role = (Role)model.Role,
                ProfilePicture = filename,
            };

            Student student = new()
            {
                MatricNumber = model.MatricNumber,
                LevelId = getLevel.Id,
                LevelName = getLevel.Name,
                DepartmentName = getDepartment.Name,
                DepartmentId = getDepartment.Id,
                FacultyName = getDepartment.FacultyName,
                FacultyId = getDepartment.FacultyId,
                UserId = user?.Id,
            };

            await _userRepository.Insert(user);
            await _studentRepository.Insert(student);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Student account created succesfully");
        }
    }
}
