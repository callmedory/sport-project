using Microsoft.AspNetCore.Http;

namespace Sport.Services.Interfaces
{
    public interface IImageService
    {
        public Task<string> UploadImageAsync(IFormFile imageFile);

        public Task<Stream> GetImageAsync(string imageName);
    }
}