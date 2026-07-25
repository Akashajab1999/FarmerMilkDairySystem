using SmartDairy.Domain.Entities;

namespace SmartDairy.Application.Features.Authentication.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task AddAsync(User user);

    Task SaveChangesAsync();
}