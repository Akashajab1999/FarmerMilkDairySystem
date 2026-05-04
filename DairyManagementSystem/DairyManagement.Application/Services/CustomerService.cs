using DairyManagement.Application.DTOs;
using DairyManagement.Domain.Entities;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repo;

    public CustomerService(ICustomerRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<CustomerDto>> GetAll()
    {
        var customers = await _repo.GetAll();

        return customers.Select(c => new CustomerDto
        {
            Id = c.Id,
            Name = c.Name,
            Village = c.Village,
            MobileNumber = c.MobileNumber
        }).ToList();
    }

    public async Task<CustomerDto> GetById(int id)
    {
        var c = await _repo.GetById(id);
        if (c == null) return null;

        return new CustomerDto
        {
            Id = c.Id,
            Name = c.Name,
            Village = c.Village,
            MobileNumber = c.MobileNumber
        };
    }

    public async Task Add(CustomerDto dto)
    {
        var customer = new Customer
        {
            Name = dto.Name,
            Village = dto.Village,
            MobileNumber = dto.MobileNumber
        };

        await _repo.Add(customer);
    }

    public async Task Update(CustomerDto dto)
    {
        var customer = await _repo.GetById(dto.Id);
        if (customer == null) return;

        customer.Name = dto.Name;
        customer.Village = dto.Village;
        customer.MobileNumber = dto.MobileNumber;

        await _repo.Update(customer);
    }

    public async Task Delete(int id)
    {
        var customer = await _repo.GetById(id);
        if (customer == null) return;

        await _repo.Delete(customer);
    }
}