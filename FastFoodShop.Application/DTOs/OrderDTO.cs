using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FastFoodShop.Application/DTOs/OrderDTO.cs
namespace FastFoodShop.Application.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerAddress { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderDetailDTO> OrderDetails { get; set; } = new();
}
