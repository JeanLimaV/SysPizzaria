using Microsoft.EntityFrameworkCore;
using SysPizzaria.Domain.Contracts.Interfaces.Repositories;
using SysPizzaria.Domain.Entities;
using SysPizzaria.Infra.Data.Context;

namespace SysPizzaria.Infra.Data.Repositories;

public class PurchasesRepository : IPurchasesRepository
{
    private readonly BaseDbContext _db;

    public PurchasesRepository(BaseDbContext db)
    {
        _db = db;
    }
    
    public async Task<Purchase> GetByIdAsync(int id)
    {
        var purcharse = await _db.Purchases
            .Include(x => x.Product)
            .Include(x => x.Person)
            .FirstOrDefaultAsync(x => x.Id == id);

        return purcharse;
    }

    public async Task<ICollection<Purchase>> GetPurchasesAsync()
    {
        return (await _db.Purchases.ToListAsync())!;
    }

    public async Task<ICollection<Purchase>> GetByPersonIdAsync(int productId)
    {
        return (await _db.Purchases
            .Include(x => x.Product)
            .Include(x => x.Person)
            .Where(x => x.ProductId == productId)
            .ToListAsync())!;
    }

    public async Task<ICollection<Purchase>> GetByProductIdAsync(int personId)
    {
        return (await _db.Purchases
            .Include(x => x.Product)
            .Include(x => x.Person)
            .Where(x => x.PersonId == personId)
            .ToListAsync())!;
    }

    public async Task<Purchase> CreateAsync(Purchase purchase)
    {
        _db.Add(purchase);
        await _db.SaveChangesAsync();
        return purchase;
    }

    public async Task UpdateAsync(Purchase purchase)
    {
        _db.Update(purchase);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Purchase purchase)
    {
        _db.Remove(purchase);
        await _db.SaveChangesAsync();
    }
}