namespace SmartDairy.Application.Features.Farmers.DTOs;

public class FarmerResponse
{
    public int Id { get; set; }

    public string FarmerCode { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

    public string Village { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}