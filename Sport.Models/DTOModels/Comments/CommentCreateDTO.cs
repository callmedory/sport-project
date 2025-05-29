using Sport.Models.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Sport.Models.DTOModels.Comments
{
    public class CommentCreateDTO
    {
        [Required(ErrorMessage = ErrorMessages.ContentIsRequired)]
        public string Content { get; set; }
    }
}
