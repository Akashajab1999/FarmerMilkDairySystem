namespace SmartDairy.Application.Features.Farmers.DTOs;

public class CreateFarmerRequest
{
    public string FarmerCode { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string Village { get; set; } = string.Empty;

    public string AadhaarNumber { get; set; } = string.Empty;
}