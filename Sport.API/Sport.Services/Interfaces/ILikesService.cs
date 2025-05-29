namespace Sport.Services.Interfaces
{
    public interface ILikesService
    {
        public Task AddLikeInfo(string articleId, string userId);
        public Task RemoveLikeInfo(string articleId, string userId);
        public Task<List<string>> GetLikeInfo(string userId);
        public Task<int> GetLikeCount(string articleId);
    }
}
