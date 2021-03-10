using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.Prompt.Models;

namespace EducationPortal.Prompt.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProfileDto, ProfileModel>().ReverseMap();
        }
    }
}
