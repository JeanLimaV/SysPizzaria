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
    
    public async Task<Purchase?> GetByIdAsync(int id)
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

    public async Task<Purchase?> GetByPersonIdAsync(int personId)
    {
        var request = await _db.Purchases
            .AsNoTracking()
            .Include(x => x.Person)
            .FirstOrDefaultAsync(x => x.Id == personId);
            
        return request;
    }

    public async Task<Purchase?> GetByProductIdAsync(int productId)
    {
        var request = await _db.Purchases
            .AsNoTracking()
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == productId);

        return request;
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