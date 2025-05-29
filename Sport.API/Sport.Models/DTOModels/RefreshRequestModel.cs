using System.ComponentModel.DataAnnotations;

namespace Sport.Models.DTOModels
{
    public class RefreshRequestModel
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
