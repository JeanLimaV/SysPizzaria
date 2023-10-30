using System.Collections.ObjectModel;
using SysPizzaria.Application.DTOs;

namespace SysPizzaria.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<PersonDTO> GetById(int id);
        Task<Collection<PersonDTO>> GetPeople();
        Task<PersonDTO?> CreateAsync(PersonDTO personDto);
        Task<PersonDTO> UpdateAsync(PersonDTO personDto);
        Task DeleteAsync(int id);
    }
}