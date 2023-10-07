using AutoMapper;
using Application.DTOs;
using Domain.Models; 

namespace Application.Mappings
{
   public class ModelToDTOMapping : Profile
    {
        public ModelToDTOMapping()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();

        }
    }
}