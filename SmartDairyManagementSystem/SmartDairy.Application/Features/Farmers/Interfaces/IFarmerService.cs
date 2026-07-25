using SmartDairy.Application.Common.Models;
using SmartDairy.Application.Features.Farmers.DTOs;

namespace SmartDairy.Application.Features.Farmers.Interfaces;

public interface IFarmerService
{
    Task<ApiResponse<FarmerResponse>> AddFarmerAsync(CreateFarmerRequest request);

    Task<ApiResponse<List<FarmerResponse>>> GetAllFarmersAsync();
}