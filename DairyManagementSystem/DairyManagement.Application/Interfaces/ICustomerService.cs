using DairyManagement.Application.DTOs;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAll();
    Task<CustomerDto> GetById(int id);
    Task Add(CustomerDto dto);
    Task Update(CustomerDto dto);
    Task Delete(int id);
}