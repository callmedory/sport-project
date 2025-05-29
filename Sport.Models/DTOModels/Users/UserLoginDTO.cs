using Sport.Models.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Sport.Models.DTOModels.Users
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = ErrorMessages.EmailIsRequired)]
        [EmailAddress(ErrorMessage = ErrorMessages.EmailNotValid)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessages.PasswordIsRequired)]
        public string Password { get; set; }
    }
}
