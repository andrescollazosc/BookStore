using AutoMapper;
using BookStore.Domain.Entities;
using BookStore.Services.Dto.Book;

namespace BookStore.Services.Api.Profiles
{
    public class MapperApi : Profile
    {
        public MapperApi()
        {
            CreateMap<Book, CreateDto>().ReverseMap();
            CreateMap<Book, ReadDto>().ReverseMap();
            CreateMap<Book, UpdateDto>().ReverseMap();
        }
    }
}
