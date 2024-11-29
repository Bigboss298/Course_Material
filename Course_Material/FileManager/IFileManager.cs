using Microsoft.AspNetCore.Http;

namespace Course_Material.FileManager
{
    public interface IFileManager
    {
        Task<(bool success, string message, string filename)> UploadProfilePicture(IFormFile formFile);
    }
}
