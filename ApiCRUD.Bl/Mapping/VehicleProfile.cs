using ApiCRUD.Bl.Dto;
using ApiCRUD.Models;
using AutoMapper;

namespace ApiCRUD.Bl.Mapping
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleDto>()
                    .ReverseMap();

            CreateMap<VehicleDto, Vehicle>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
             
            CreateMap<Owner, OwnerDto>()
                .ForMember(dest => dest.Vehicles, opt => opt.Ignore())
                .ReverseMap();
            
            CreateMap<OwnerDto, Owner>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
