using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.DTOs;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository,  IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDTO>> GetContacts()
        {
            var contactsEntity = await _contactRepository.GetContacts();
            return _mapper.Map<IEnumerable<ContactDTO>>(contactsEntity);

        }

        public async Task<ContactDTO> GetById(int id)
        {
            var contactEntity = await _contactRepository.GetById(id);
            return _mapper.Map<ContactDTO>(contactEntity);
        }

        public async Task Add(ContactDTO contactDto)
        {
            var contactEntity = _mapper.Map<Contact>(contactDto);
            await _contactRepository.Create(contactEntity);
            contactDto.Id = contactEntity.Id;
        }

        public async Task Update(ContactDTO contactDto)
        {
            var contactEntity = _mapper.Map<Contact>(contactDto);
            await _contactRepository.Update(contactEntity);
        }

        public async Task Remove(int id)
        {
            var contactEntity = _contactRepository.GetById(id).Result;
            await _contactRepository.Remove(contactEntity);
        }

    }
}
