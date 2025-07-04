﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FastFoodShop.Application/DTOs/ProductDTO.cs
namespace FastFoodShop.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public bool IsFeatured { get; set; }
}