using AutoMapper;
using People.Domain.Models;
using People.MvcUi.Models;

namespace People.MvcUi;

public class Profiles : Profile
{
	public Profiles()
	{
		CreateMap<PersonCreateModel, Person>()
			.ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.Contact))
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
			.ReverseMap();
		CreateMap<PersonContactModel, ContactInfo>()
			.ReverseMap();
		CreateMap<PersonNameModel, PersonName>() // TSource, TDestination			
			.ReverseMap();
		CreateMap<PersonUpdateModel, Person>()
			.ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.Contact))
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
			.ReverseMap();
	}
}
