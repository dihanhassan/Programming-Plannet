using AutoMapper;
using BlogPost.Application.Dto.Response;
using BlogPost.Domain.Entities;

namespace BlogPostWebApi.Mappers
{
    public class ResponseMapper : Profile
    {
        public ResponseMapper()
        {
            CreateMap<User, UserResponse>();
            CreateMap<User, UserLoginResponse>();
        }
    }
}
