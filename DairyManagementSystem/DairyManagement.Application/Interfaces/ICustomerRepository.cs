using DairyManagement.Domain.Entities;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAll();
    Task<Customer> GetById(int id);
    Task Add(Customer customer);
    Task Update(Customer customer);
    Task Delete(Customer customer);
}