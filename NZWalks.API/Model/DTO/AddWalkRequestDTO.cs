using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Model.DTO
{
    public class AddWalkRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0,30, ErrorMessage = "LengthInKm lies in between 0km to 30km")]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }
    }
}
