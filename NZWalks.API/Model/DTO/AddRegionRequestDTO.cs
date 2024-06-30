using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Model.DTO
{
    public class AddRegionRequestDTO
    {
        [Required]
        [MinLength(3,ErrorMessage = "Code MinLength is 3")]
        [MaxLength(3,ErrorMessage = "Code MaxLength is 3")]
        public string Code { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "Name MaxLength is 40")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
