using Sport.Models.DTOModels.Users;
using Sport.Models.Entities;

namespace Sport.Models.DTOModels.Articles
{
    public class ArticleWithContentDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public SportType Sport { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public List<string> Tags { get; set; }

        public int LikeCount { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public UserInfo Author { get; set; }

        public ArticleStatus Status { get; set; }

        public string Content { get; set; }
    }
}
