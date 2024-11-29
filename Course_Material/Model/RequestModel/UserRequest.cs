
using Course_Material.Model.Enums;

namespace Course_Material.Model.RequestModel
{
    public class StudentAccountRequest
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public IFormFile ProfilePicture { get; set; } = default!;
        public int Gender { get; set; } = default!;
        public int Role { get; set; } = default!;
        public string MatricNumber { get; set; } = default!;
        public string LevelId { get; set; } = default!;
        public string DepartmentId { get; set; } = default!;
    }
    public class LecturerAccountRequest
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public IFormFile ProfilePicture { get; set; } = default!;
        public int Gender { get; set; } = default!;
        public int Role { get; set; } = default!;
        public string DepartmentId { get; set; } = default!;
        public string FacultyId { get; set; } = default!;
    }
    public class GetUser
    {
        public string Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Role Role { get; set; }
        public Gender Gender { get; set; }
        public string? ProfilePicture { get; set; }
    }
    public class GetUserWithToken
    {
        public GetUser User { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
