

namespace Course_Material.Model.RequestModel
{
    public class JwtTokenRequest
    {
        public string Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Token { get; set; }
        public string Role { get; set; } = default!;
    }
}
