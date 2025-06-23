using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FastFoodShop.Application/Services/IProductService.cs
using FastFoodShop.Application.DTOs;

namespace FastFoodShop.Application.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    Task<ProductDTO> GetProductByIdAsync(int id);
    Task AddProductAsync(ProductDTO productDto);
    Task UpdateProductAsync(ProductDTO productDto);
    Task DeleteProductAsync(int id);
    Task<IEnumerable<ProductDTO>> GetFeaturedProductsAsync();
}
