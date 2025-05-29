using Sport.Models.Entities;
using Sport.Models.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Sport.Models.DTOModels.Users
{
    public class ChangeUserRoleDTO
    {
        [Required(ErrorMessage = ErrorMessages.RoleIsRequired)]
        public UserRoles NewUserRole { get; set; }
    }
}
