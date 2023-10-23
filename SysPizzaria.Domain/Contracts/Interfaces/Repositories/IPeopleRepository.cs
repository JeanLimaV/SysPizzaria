using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Domain.Contracts.Interfaces.Repositories
{
    public interface IPeopleRepository
    {
        Task<Person> GetByDocument(string document);
        Task<Person> GetByIdAsync(int id);
        Task<ICollection<Person>> GetPeopleAsync();
        Task<Person> CreateAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Person person);
    }
}