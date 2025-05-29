using Sport.Models.DTOModels.Comments;
using Sport.Models.Entities;

namespace Sport.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<CommentListDTO> GetCommentsByArticleIdAsync(string articleId, int pageNumber, int pageSize);

        public Task<CommentDTO> AddCommentAsync(CommentCreateDTO commentDto, string articleId, string userId);

        public Task DeleteCommentAsync(string commentId, string userId);
    }
}
