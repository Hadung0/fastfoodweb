using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FastFoodShop.Domain/Entities/Order.cs
namespace FastFoodShop.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerAddress { get; set; }
    public decimal TotalAmount { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}