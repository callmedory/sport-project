using Sport.Models.Entities;

namespace Sport.Repository.Interfaces
{
    public interface IFavoritesRepository
    {
        public Task<Favorites> GetById(string id);
        public Task UpdateAsync(Favorites favorites);
        public Task<List<Favorites>> GetFavoritesWithArticle(string id);
    }
}
