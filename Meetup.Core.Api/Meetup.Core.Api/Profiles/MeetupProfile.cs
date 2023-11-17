using AutoMapper;
using Meetup.Core.Data.Dtos;
using Meetup.Core.Data.Entities;

namespace Meetup.Core.Api.Profiles
{
    public class MeetupProfile : Profile
    {
        public MeetupProfile()
        {
            CreateMap<Data.Entities.Meetup, MeetupDetailsDto>()
                .ForMember(m => m.City, map => map.MapFrom(meetup => meetup.Location.City))
                .ForMember(m => m.PostCode, map => map.MapFrom(meetup => meetup.Location.PostCode))
                .ForMember(m => m.Street, map => map.MapFrom(meetup => meetup.Location.Street));

            CreateMap<MeetupDto, Data.Entities.Meetup>();

            CreateMap<LectureDto, Lecture>()
                .ReverseMap();
        }
    }
}
