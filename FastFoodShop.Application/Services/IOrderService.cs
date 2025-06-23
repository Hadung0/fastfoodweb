using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FastFoodShop.Application/Services/IOrderService.cs
using FastFoodShop.Application.DTOs;

namespace FastFoodShop.Application.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
    Task<OrderDTO> GetOrderByIdAsync(int id);
    Task<int> CreateOrderAsync(OrderDTO orderDto);
    Task<IEnumerable<OrderDTO>> GetOrdersByDateAsync(DateTime date);
}
