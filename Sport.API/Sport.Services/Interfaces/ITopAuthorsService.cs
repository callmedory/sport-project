using Sport.Models.DTOModels.Users;

namespace Sport.Services.Interfaces
{
    public interface ITopAuthorsService
    {
        public Task<IEnumerable<AuthorDTO>> GetTopAuthorsAsync(int pageNumber, int pageSize);
    }
}
