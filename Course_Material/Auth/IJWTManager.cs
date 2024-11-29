
using Course_Material.Model.RequestModel;

namespace Course_Material.Auth
{
    public interface IJWTManager
    {
        string CreateToken(string key, string issuer, JwtTokenRequest model);
        //bool IsTokenValid(string key, string issuer, string token);
    }
}
