using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFoodShop.Domain.Entities;

// FastFoodShop.Domain/Interfaces/IOrderRepository.cs
namespace FastFoodShop.Domain.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(int id);
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime date);
}