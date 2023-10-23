using SysPizzaria.Application.DTOs;

namespace SysPizzaria.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<PersonDTO> GetById(int id);
        Task<ICollection<PersonDTO>> GetPeople();
        Task<PersonDTO?> CreateAsync(PersonDTO? personDto);
        Task<PersonDTO> UpdateAsync(PersonDTO personDto);
        Task DeleteAsync(PersonDTO personDto);
    }
}