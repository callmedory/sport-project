using Microsoft.Azure.CosmosRepository.Attributes;
using Newtonsoft.Json;

namespace Sport.Models.Entities
{
    [PartitionKeyPath("/partitionKey")]
    public class Tag : BaseModel
    {
        [JsonProperty("tags")]
        public string TagName { get; set; }

        [JsonProperty("articleId")]
        public HashSet<string> ArticleIds { get; set; }

        [JsonProperty("count")]
        public int ArticleCount { get; set; }
    }
}
