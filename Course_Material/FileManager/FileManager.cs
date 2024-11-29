using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Course_Material.FileManager;

public class FileManager(IWebHostEnvironment webHostEnvironment) : IFileManager
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public async Task<(bool success, string message, string filename)> UploadProfilePicture(IFormFile formFile)
    {
        var fileDestinationPath = Path.Combine(_webHostEnvironment.WebRootPath, "ProfilePictures");

        if (formFile == null || formFile.Length <= 0)
            return (false, "file not found", "");

        var acceptableExtension = new List<string> { ".jpg", ".jpeg", ".png" };

        var fileExtension = Path.GetExtension(formFile.FileName);
        if (!acceptableExtension.Contains(fileExtension))
            return (false, "File format not supported, please upload any of the following formats (jpg, jpeg, png)", "");

        const long maxFileSizeInBytes = 1 * 1024 * 1024;
        if (formFile.Length > maxFileSizeInBytes)
            return (false, "File size exceeds the maximum limit of 1MB", "");

        if (!Directory.Exists(fileDestinationPath))
            Directory.CreateDirectory(fileDestinationPath);

        var fileName = $"{Guid.NewGuid().ToString()[..4]}{formFile.FileName}";
        var destinationFullPath = Path.Combine(fileDestinationPath, fileName);

        using (var stream = new FileStream(destinationFullPath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
        }

        return (true, "Profile picture uploaded successfully", fileName);
    }
}
