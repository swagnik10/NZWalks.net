using AutoMapper;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;

namespace NZWalks.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
       public AutoMapperProfile() 
        {
            CreateMap<Regions,RegionsDTO>().ReverseMap();
            CreateMap<AddRegionRequestDTO,Regions>().ReverseMap();
        }
    }
}
