using Course_Material.FileManager;
using Course_Material.Interface.Repositories;
using Course_Material.Interface.Service;
using Course_Material.Model.Entities;
using Course_Material.Model.Enums;
using Course_Material.Model.Exceptions;
using Course_Material.Model.RequestModel;

namespace Course_Material.Implementation.Service
{
    public class LecturerService(IRepositoryManager repositoryManager, IFileManager fileManager) : ILecturerService
    {
        private readonly ILecturerRepository _lecturerRepository = repositoryManager.LecturerRepository;
        private readonly IUserRepository _userRepository = repositoryManager.UserRepository;
        private readonly IDepartmentRepository _departmentRepository = repositoryManager.DepartmentRepository;
        private readonly ILevelRepository _levelRepository = repositoryManager.LevelRepository;
        private readonly IFileManager _fileManager = fileManager;
        private readonly IUnitOfWork _unitOfWork = repositoryManager.UnitOfWork;
        public async Task<(bool success, string message)> Create(LecturerAccountRequest model)
        {
            var checkUser = await _userRepository.CheckUser(model.Email);
            if (checkUser) throw new BadRequestException($"A user already registered with the email :{model.Email}");

            var checkUserName = await _userRepository.CheckUserName(model.Username);
            if (checkUserName) throw new BadRequestException($"The user name {model.Username} has been choseen");

            var getDepartment = await _departmentRepository.GetSingle(x => x.Id == model.DepartmentId) ?? throw new BadRequestException("Department doesn't exist");

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

            Lecturer lecturer = new()
            {
                DepartmentName = getDepartment.Name,
                DepartmentId = getDepartment.Id,
                FacultyName = getDepartment.FacultyName,
                FacultyId = getDepartment.FacultyId,
            };

            await _userRepository.Insert(user);
            await _lecturerRepository.Insert(lecturer);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Student account created succesfully");

        }
    }
}
