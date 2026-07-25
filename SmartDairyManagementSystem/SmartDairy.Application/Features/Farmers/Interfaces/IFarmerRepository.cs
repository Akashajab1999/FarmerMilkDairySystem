using SmartDairy.Domain.Entities;

namespace SmartDairy.Application.Features.Farmers.Interfaces;

public interface IFarmerRepository
{
    Task<List<Farmer>> GetAllAsync();

    Task<Farmer?> GetByIdAsync(int id);

    Task AddAsync(Farmer farmer);

    void Update(Farmer farmer);

    void Delete(Farmer farmer);

    Task SaveChangesAsync();
}