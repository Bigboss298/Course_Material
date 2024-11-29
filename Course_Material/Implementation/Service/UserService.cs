using Course_Material.Auth;
using Course_Material.Interface.Repositories;
using Course_Material.Interface.Service;
using Course_Material.Model.RequestModel;
using Course_Material.Model.ResponseModel;

namespace Course_Material.Implementation.Service
{
    public class UserService(IRepositoryManager repositoryManager, IJWTManager tokenService, IConfiguration config) : IUserService
    {
        private readonly IUserRepository _userRepository = repositoryManager.UserRepository;
        private readonly IUnitOfWork _unitOfWork = repositoryManager.UnitOfWork;
        private readonly IJWTManager _tokenService = tokenService;
        private readonly IConfiguration _config = config;

        public async Task<List<GetUser>> GetAll()
        {
            var users = await _userRepository.GetAll();
            if (!users.Any()) return [];

            return users.Select(u => new GetUser {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Role = u.Role,
                Gender = u.Gender,
                ProfilePicture = u.ProfilePicture
            }).ToList();
        }

        public async Task<BaseResponse<GetUserWithToken>> Login(string username, string password)
        {
            var userLogin = await _userRepository.LoginAsync(username, password);
            if(userLogin is null)
            {
                return new BaseResponse<GetUserWithToken>
                {
                    Message = "Invalid Credentials",
                    Success = false,
                };
            }
            var jwtModel = new JwtTokenRequest
            {
                Id = userLogin.Id,
                FirstName = userLogin.FirstName,
                Email = userLogin.Email,
                Role = userLogin.Role.ToString(),
            };

            var token = _tokenService.CreateToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), jwtModel);
            userLogin.Token = token;

            await _unitOfWork.SaveChangesAsync();

            var getUser = new GetUser
            {
                Id = userLogin.Id,
                FirstName = userLogin.FirstName,
                LastName = userLogin.LastName,
                Email = userLogin.Email,
                Role = userLogin.Role,
                Gender = userLogin.Gender,
                ProfilePicture = userLogin.ProfilePicture,
            };

            return new BaseResponse<GetUserWithToken>
            {
                Success = true,
                Message = "Login Successful!",
                Data = new GetUserWithToken
                {
                    User = getUser,
                    Token = token,
                }
            };
        }
    }
}
