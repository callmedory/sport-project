using Sport.Models.DTOModels.Users;

namespace Sport.Models.DTOModels.Comments
{
    public class CommentDTO
    {
        public UserInfo Author { get; set; }
        public string CommentId { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
