using Course_Material.Model.Enums;

namespace Course_Material.Model.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ProfilePicture { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public Role Role { get; set; } = default!;
        public string? Token { get; set; } 
    }
}
