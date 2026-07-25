using SmartDairy.Application.Common.Models;
using SmartDairy.Application.Features.Farmers.DTOs;
using SmartDairy.Application.Features.Farmers.Interfaces;
using SmartDairy.Domain.Entities;

namespace SmartDairy.Application.Features.Farmers.Services;

public class FarmerService : IFarmerService
{
    private readonly IFarmerRepository _repository;

    public FarmerService(IFarmerRepository repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<FarmerResponse>> AddFarmerAsync(CreateFarmerRequest request)
    {
        var farmer = new Farmer
        {
            FarmerCode = request.FarmerCode,
            FirstName = request.FirstName,
            LastName = request.LastName,
            MobileNumber = request.MobileNumber,
            Address = request.Address,
            Village = request.Village,
            AadhaarNumber = request.AadhaarNumber,
            IsActive = true
        };

        await _repository.AddAsync(farmer);
        await _repository.SaveChangesAsync();

        var response = new FarmerResponse
        {
            Id = farmer.Id,
            FarmerCode = farmer.FarmerCode,
            FullName = $"{farmer.FirstName} {farmer.LastName}",
            MobileNumber = farmer.MobileNumber,
            Village = farmer.Village,
            IsActive = farmer.IsActive
        };

        return ApiResponse<FarmerResponse>.SuccessResponse(
            response,
            "Farmer added successfully.");
    }

    public async Task<ApiResponse<List<FarmerResponse>>> GetAllFarmersAsync()
    {
        var farmers = await _repository.GetAllAsync();

        var response = farmers.Select(x => new FarmerResponse
        {
            Id = x.Id,
            FarmerCode = x.FarmerCode,
            FullName = $"{x.FirstName} {x.LastName}",
            MobileNumber = x.MobileNumber,
            Village = x.Village,
            IsActive = x.IsActive
        }).ToList();

        return ApiResponse<List<FarmerResponse>>.SuccessResponse(
            response,
            "Farmers fetched successfully.");
    }
}