using AutoMapper;
using Exam_Portal.Application.DTOs.User;
using Exam_Portal.Core.Entities;


namespace Exam_Portal.Utils.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
