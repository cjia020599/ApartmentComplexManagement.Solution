using AutoMapper;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Infrastructure.MappingProfiles
{
    public class PropertyMappingProfile : Profile
    {
        public PropertyMappingProfile()
        {
            CreateMap<PropertyUnit, PropertyResponse>()
                .ForMember(p => p.Id, options => options.MapFrom(p => p.Id.Value));
        }
    }
}
