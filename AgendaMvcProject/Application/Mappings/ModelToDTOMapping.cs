using AutoMapper;
using AgendaMvcProject.Application.DTOs;
using AgendaMvcProject.Domain.Models; 

namespace AgendaMvcProject.Application.Mappings
{
    class ModelToDTOMapping : Profile
    {
        public ModelToDTOMapping()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}