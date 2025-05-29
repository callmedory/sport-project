﻿using Microsoft.Azure.CosmosRepository.Attributes;
using Newtonsoft.Json;

namespace Sport.Models.Entities
{
    [PartitionKeyPath("/partitionKey")]
    public class AuthorStatistics : BaseModel
    {
        [JsonProperty("authorId")]
        public string AuthorId { get; set; }

        [JsonProperty("articleCount")]
        public int ArticleCount { get; set; }
    }
}
