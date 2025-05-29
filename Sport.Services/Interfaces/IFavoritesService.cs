using Sport.Models.Entities;

namespace Sport.Services.Interfaces
{
    public interface IFavoritesService
    {
        public Task AddFavorite(string userId, string articleId);
        public Task RemoveFavorite(string userId, string articleId);
        public Task<HashSet<string>> GetFavorites(string id, int pageNumber, int pageSize, string orderBy);
        public Task<Favorites> FindFavorites(string userId);
        public Task<HashSet<string>> GetFavoritesIDs(string userId);
        public Task DeleteArticleFromFavorites(string articleId);
    }
}
