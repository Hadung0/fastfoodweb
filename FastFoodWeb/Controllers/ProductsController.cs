using Microsoft.AspNetCore.Mvc;
// FastFoodShop.Web/Controllers/ProductsController.cs
using FastFoodShop.Application.DTOs;
using FastFoodShop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet("featured")]
    public async Task<IActionResult> GetFeaturedProducts()
    {
        var products = await _productService.GetFeaturedProductsAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDTO productDto)
    {
        await _productService.AddProductAsync(productDto);
        return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductDTO productDto)
    {
        if (id != productDto.Id) return BadRequest();
        await _productService.UpdateProductAsync(productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
}