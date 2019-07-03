using AutoMapper;
using DatingApp.API.Models;
using DatingApp.API.Dtos;
using System.Linq;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
              var mapper = new MapperConfiguration(config => { config.ValidateInlineMaps = false; }).CreateMapper();

            CreateMap<User,UserForDetailedDto>()
                .ForMember(dest=>dest.PhotoUrl, opt => { 
                    opt.MapFrom(src =>src.Photos.FirstOrDefault(p =>p.IsMain).Url);
                })
                .ForMember(dest=>dest.Age, opt => { 
                    opt.ResolveUsing(d=>d.DateOfBirth.CalculateAge());
                });
            CreateMap<User,UserForListDto>() 
                .ForMember(dest=>dest.PhotoUrl, opt => { 
                    opt.MapFrom(src =>src.Photos.FirstOrDefault(p =>p.IsMain).Url);
                })
                .ForMember(dest=>dest.Age, opt => { 
                    opt.ResolveUsing(d=>d.DateOfBirth.CalculateAge());
                });
            CreateMap<Photo,PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto,User>();
        }
    }
}