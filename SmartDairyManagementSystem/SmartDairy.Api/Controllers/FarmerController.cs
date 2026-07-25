using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDairy.Application.Features.Farmers.DTOs;
using SmartDairy.Application.Features.Farmers.Interfaces;

namespace SmartDairy.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FarmerController : ControllerBase
{
    private readonly IFarmerService _farmerService;

    public FarmerController(IFarmerService farmerService)
    {
        _farmerService = farmerService;
    }

    [HttpPost]
    public async Task<IActionResult> AddFarmer(CreateFarmerRequest request)
    {
        var result = await _farmerService.AddFarmerAsync(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFarmers()
    {
        var result = await _farmerService.GetAllFarmersAsync();

        return Ok(result);
    }
}