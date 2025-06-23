using Microsoft.AspNetCore.Mvc;

// FastFoodShop.Web/Controllers/OrdersController.cs
using FastFoodShop.Application.DTOs;
using FastFoodShop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodShop.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null) return NotFound();
        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrderDTO orderDto)
    {
        var orderId = await _orderService.CreateOrderAsync(orderDto);
        return CreatedAtAction(nameof(GetById), new { id = orderId }, orderDto);
    }

    [HttpGet("date/{date}")]
    public async Task<IActionResult> GetByDate(DateTime date)
    {
        var orders = await _orderService.GetOrdersByDateAsync(date);
        return Ok(orders);
    }
}
