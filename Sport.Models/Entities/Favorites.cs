using Newtonsoft.Json;

namespace Sport.Models.Entities
{
    public class Favorites : BaseModel
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("favoriteArticles")]
        public HashSet<string> FavoriteArticles { get; set; }
    }
}
