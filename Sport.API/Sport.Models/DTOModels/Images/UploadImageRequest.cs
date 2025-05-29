using Microsoft.AspNetCore.Http;

namespace Sport.Models.DTOModels.Images
{
    public record UploadDocumentVersionRequest
    {
        public IFormFile File { get; init; }
    }
}
