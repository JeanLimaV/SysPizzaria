using System.Collections.ObjectModel;
using AutoMapper;
using SysPizzaria.Application.DTOs;
using SysPizzaria.Application.Interfaces;
using SysPizzaria.Application.Services.Interfaces;
using SysPizzaria.Domain.Contracts.Interfaces.Repositories;
using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IPeopleRepository _peopleRepository;
        private readonly INotificator _notificator;
        
        public PersonService(IMapper mapper, IPeopleRepository peopleRepository, INotificator notificator)
        {
            _mapper = mapper;
            _peopleRepository = peopleRepository;
            _notificator = notificator;
        }

        public async Task<PersonDTO> GetById(int id)
        {
            var person = await _peopleRepository.GetByIdAsync(id);
            if (person == null)
                throw new AppDomainUnloadedException("Não existe nenhuma pessoa com esse Id!");

            return _mapper.Map<PersonDTO>(person);
        }

        public async Task<Collection<PersonDTO>> GetPeople()
        {
            var allPeople = await _peopleRepository.GetPeopleAsync();

            return _mapper.Map<Collection<PersonDTO>>(allPeople);
        }

        public async Task<PersonDTO?> CreateAsync(PersonDTO personDto)
        {
            var personExists = await _peopleRepository.GetByDocument(personDto.Document);

            if (personExists != null)
                throw new AppDomainUnloadedException("Esta Pessoa já está cadastrada!");
            
            var person = _mapper.Map<Person>(personDto);
            if (!PersonValidate(person))
                return null;
            
            await _peopleRepository.CreateAsync(person);
            return personDto;
        }

        public async Task<PersonDTO> UpdateAsync(PersonDTO personDto)
        {
            var personExists = await _peopleRepository.GetByIdAsync(personDto.Id);
            if (personExists == null)
                throw new AppDomainUnloadedException("Não existe nenhuma pessoa com esse Id cadastrada!");

            var person = _mapper.Map<Person>(personDto);
            if (!PersonValidate(person))
                return null;
            
            await _peopleRepository.UpdateAsync(person);
            return personDto;
        }

        public async Task DeleteAsync(int id)
        {
            var personExists = await _peopleRepository.GetByIdAsync(id);
            if (personExists == null)
                throw new AppDomainUnloadedException("Não existe nenhuma pessoa com esse Id!");
            
            await _peopleRepository.DeleteAsync(personExists);
        }
        
        private bool PersonValidate(Person person)
        {
            if (!person.Validate(out var validationResult))
            {
                _notificator.Handle(validationResult.Errors);
                return false;
            }

            return true;
        }
    }
}
