using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace SportsStore.Infrastructure
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtensions);

        void DeleteFile(string fileNameWithExtension);
    }

    public class FileService(IWebHostEnvironment environment) : IFileService
    {
        public async Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtensions)
        {
            // Checks if the user has entered an image or not
            if (imageFile == null)
            {
                throw new ArgumentNullException(nameof(imageFile));
            }

            // Creates the path for the folder that holds the image
            var rootPath = environment.ContentRootPath;
            var folderPath = Path.Combine(rootPath, "images");

            // Checks if the path for the folder exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Checks if the extension is allowed
            var extension = Path.GetExtension(imageFile.FileName);
            if (!allowedFileExtensions.Contains(extension))
            {
                throw new ArgumentException($"Only {string.Join(",",
                    allowedFileExtensions)} are allowed.");
            }

            // Creates a randomized image path with the extension
            var fileName = $"{Guid.NewGuid().ToString()} {extension}";
            var imagePath = Path.Combine(folderPath, fileName);

            // Uploads the image as a file stream
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return fileName;
        }

        public void DeleteFile(string fileNameWithExtension)
        {
            if (string.IsNullOrEmpty(fileNameWithExtension))
            {
                throw new ArgumentNullException(nameof(fileNameWithExtension));
            }

            var rootPath = environment.ContentRootPath;
            var path = Path.Combine(rootPath, "images", fileNameWithExtension);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Invalid file path");
            }

            File.Delete(path);
        }
    }
}
