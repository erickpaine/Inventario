using AutoMapper;
using Inventario.Dto;
using Inventario.Modelos;


public class ProductoProfile : Profile
{
    public ProductoProfile()
    {

        CreateMap<ProductoDto, Producto>();
        CreateMap<Producto,  ProductoDto>();
    }
}