using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FastFoodShop.Application/Services/OrderService.cs
using AutoMapper;
using FastFoodShop.Application.DTOs;
using FastFoodShop.Domain.Entities;
using FastFoodShop.Domain.Interfaces;

namespace FastFoodShop.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public OrderService(
        IOrderRepository orderRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderDTO>>(orders);
    }

    public async Task<OrderDTO> GetOrderByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        return _mapper.Map<OrderDTO>(order);
    }

    public async Task<int> CreateOrderAsync(OrderDTO orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        order.OrderDate = DateTime.Now;

        // Calculate total amount
        order.TotalAmount = orderDto.OrderDetails.Sum(od => od.Quantity * od.UnitPrice);

        // Add order details
        order.OrderDetails = orderDto.OrderDetails
            .Select(od => new OrderDetail
            {
                ProductId = od.ProductId,
                Quantity = od.Quantity,
                UnitPrice = od.UnitPrice
            }).ToList();

        await _orderRepository.AddAsync(order);
        return order.Id;
    }

    public async Task<IEnumerable<OrderDTO>> GetOrdersByDateAsync(DateTime date)
    {
        var orders = await _orderRepository.GetOrdersByDateAsync(date);
        return _mapper.Map<IEnumerable<OrderDTO>>(orders);
    }
}
