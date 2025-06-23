using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FastFoodShop.Application/Services/ICategoryService.cs
using FastFoodShop.Application.DTOs;

namespace FastFoodShop.Application.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
    Task<CategoryDTO> GetCategoryByIdAsync(int id);
    Task AddCategoryAsync(CategoryDTO categoryDto);
    Task UpdateCategoryAsync(CategoryDTO categoryDto);
    Task DeleteCategoryAsync(int id);
}
