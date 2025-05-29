using Sport.Models.Entities;
using System.Linq.Expressions;

namespace Sport.Repository.Interfaces
{
    public interface IAuthorStatisticsRepository
    {
        public Task<AuthorStatistics> GetAuthorStatisticsAsync(string authorId);

        public Task<IEnumerable<AuthorStatistics>> GetAuthorsPageAsync(Expression<Func<AuthorStatistics, bool>> predicate, int pageNumber, int pageSize);

        public Task CreateAuthorStatisticsAsync(string authorId);

        public Task UpdateAuthorStatisticsAsync(string authorId, int articleCount);
    }
}
