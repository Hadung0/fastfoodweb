﻿using Microsoft.AspNetCore.Mvc;

// FastFoodShop.Web/Controllers/CategoriesController.cs
using FastFoodShop.Application.DTOs;
using FastFoodShop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDTO categoryDto)
    {
        await _categoryService.AddCategoryAsync(categoryDto);
        return CreatedAtAction(nameof(GetById), new { id = categoryDto.Id }, categoryDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CategoryDTO categoryDto)
    {
        if (id != categoryDto.Id) return BadRequest();
        await _categoryService.UpdateCategoryAsync(categoryDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return NoContent();
    }
}