namespace SmartDairy.Domain.Entities;

public class Farmer : BaseEntity
{
    public string FarmerCode { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string Village { get; set; } = string.Empty;

    public string AadhaarNumber { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}