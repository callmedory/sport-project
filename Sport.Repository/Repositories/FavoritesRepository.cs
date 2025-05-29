using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Extensions;
using Sport.Models.Entities;
using Sport.Repository.Interfaces;

namespace Sport.Repository.Repositories
{
    public class FavoritesRepository : IFavoritesRepository
    {
        private readonly IRepository<Favorites> _repository;

        public FavoritesRepository(IRepository<Favorites> repository)
        {
            _repository = repository;
        }

        public async Task<Favorites> GetById(string id)
        {
            var favorites = await _repository.GetAsync(x => x.UserId == id).FirstOrDefaultAsync();
            return favorites;
        }

        public async Task UpdateAsync(Favorites favorites)
        {
            favorites.PartitionKey = favorites.Id;
            if (await GetById(favorites.UserId) == null)
            {
                await _repository.CreateAsync(favorites);
            }
            await _repository.UpdateAsync(favorites, default);
        }

        public async Task<List<Favorites>> GetFavoritesWithArticle(string id)
        {
            var favorites = await _repository.GetAsync(x => x.FavoriteArticles.Contains(id)).ToListAsync();
            return favorites;
        }
    }
}
