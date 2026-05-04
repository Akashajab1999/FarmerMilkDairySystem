using Microsoft.EntityFrameworkCore;
using DairyManagement.Domain.Entities;

namespace DairyManagement.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}