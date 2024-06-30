using NZWalks.API.Model.Domain;

namespace NZWalks.API.Model.DTO
{
    public class WalksDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }


        //Navigation properties
        public Difficulty Difficulty { get; set; }
        public Regions Region { get; set; }
    }
}
