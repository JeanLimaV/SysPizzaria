using Microsoft.EntityFrameworkCore;
using SysPizzaria.Domain.Contracts.Interfaces.Repositories;
using SysPizzaria.Domain.Entities;
using SysPizzaria.Infra.Data.Context;

namespace SysPizzaria.Infra.Data.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly BaseDbContext _db;

        public PeopleRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<int> GetByDocument(string document)
        {
            // return (await _db.People.FirstOrDefaultAsync(c => c.Document == document))?.Id ?? 0;
            
            return (await _db.People.FirstOrDefaultAsync(c => string.Equals(c.Document, document, StringComparison.OrdinalIgnoreCase)))?.Id ?? 0;
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            var request = await _db.People
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            
            return request;
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _db.People.ToListAsync();
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task UpdateAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }
    }
}
