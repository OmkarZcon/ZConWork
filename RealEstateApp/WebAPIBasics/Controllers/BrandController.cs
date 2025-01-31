﻿using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Services;

[Route("api/v1/brand-management/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet("getall")]
    public IActionResult GetAllBrands()
    {
        var brands = _brandService.GetAllBrands();
        return Ok(brands);
    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetBrandById(int id)
    {
        var brand = _brandService.GetBrandById(id);
        if (brand == null)
            return NotFound();

        return Ok(brand);
    }

    [HttpPost("create")]
    public IActionResult CreateBrand([FromBody] string brandName)
    {
        var brand = _brandService.CreateBrand(brandName);
        return CreatedAtAction(nameof(GetAllBrands), brand);
    }

    [HttpPut("update/{id}")]
    public IActionResult UpdateBrand(int id, [FromBody] string brandName)
    {
        var updatedBrand = _brandService.UpdateBrand(id, brandName);
        if (updatedBrand == null)
            return NotFound();
        return Ok(updatedBrand);
    }

     [HttpDelete("delete/{id}")]
    public IActionResult DeleteBrand(int id)
    {
        var success = _brandService.DeleteBrand(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}