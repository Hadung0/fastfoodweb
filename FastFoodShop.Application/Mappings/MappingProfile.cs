using AutoMapper;
using FastFoodShop.Application.DTOs;
using FastFoodShop.Domain.Entities;

namespace FastFoodShop.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Product mappings
        CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<ProductDTO, Product>();

        // Category mappings
        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category>();

        // Order mappings
        CreateMap<Order, OrderDTO>();
        CreateMap<OrderDTO, Order>();

        // OrderDetail mappings
        CreateMap<OrderDetail, OrderDetailDTO>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        CreateMap<OrderDetailDTO, OrderDetail>();
    }
}