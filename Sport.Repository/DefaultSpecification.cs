using Microsoft.Azure.CosmosRepository.Specification;
using System.Linq.Expressions;
using Sport.Models.Entities;
using Sport.Models;

namespace Sport.Repository
{
    public class DefaultArticleSpecification : DefaultSpecification<Article>
    {
        public DefaultArticleSpecification(int pageNumber, int pageSize, string orderBy,
            Expression<Func<Article, bool>> predicate, HashSet<string> articleIds)
        {
            var query = Query;
            if (predicate != default)
            {
                Query.Where(predicate);
            }

            if (articleIds != default && articleIds.Any())
            {
                Query.Where(x => articleIds.Contains(x.Id));
            }

            switch (orderBy)
            {
                case OrderType.byCreatedDateAsc:
                    Query.OrderBy(x => x.CreatedTimeUtc);
                    break;
                case OrderType.topRated:
                    Query.OrderByDescending(x => x.LikeCount);
                    break;
                default:
                    Query.OrderByDescending(x => x.CreatedTimeUtc);
                    break;
            }

            Query.PageSize(pageSize)
                .PageNumber(pageNumber);
        }
    }
}
