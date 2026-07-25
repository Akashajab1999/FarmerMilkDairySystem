using Microsoft.EntityFrameworkCore;
using SmartDairy.Application.Features.Farmers.Interfaces;
using SmartDairy.Domain.Entities;
using SmartDairy.Persistence.Contexts;

namespace SmartDairy.Persistence.Repositories;

public class FarmerRepository : IFarmerRepository
{
    private readonly AppDbContext _context;

    public FarmerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Farmer>> GetAllAsync()
    {
        return await _context.Farmers
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.FirstName)
            .ToListAsync();
    }

    public async Task<Farmer?> GetByIdAsync(int id)
    {
        return await _context.Farmers
            .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task AddAsync(Farmer farmer)
    {
        await _context.Farmers.AddAsync(farmer);
    }

    public void Update(Farmer farmer)
    {
        _context.Farmers.Update(farmer);
    }

    public void Delete(Farmer farmer)
    {
        farmer.IsDeleted = true;
        _context.Farmers.Update(farmer);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}