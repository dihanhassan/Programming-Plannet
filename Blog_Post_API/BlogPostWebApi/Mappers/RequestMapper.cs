using AutoMapper;
using BlogPost.Application.Dto.Request;
using BlogPost.Domain.Entities;

namespace BlogPostWebApi.Mappers
{
    public class RequestMapper : Profile
    {
        public RequestMapper()
        {
            CreateMap<UserRequest, User>();
        }
    }
}
