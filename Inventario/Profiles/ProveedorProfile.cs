using AutoMapper;
using Inventario.Dto;
using Inventario.Modelos;

namespace Inventario.Profiles
{
    public class ProveedorProfile : Profile
    {
        public ProveedorProfile()
        {
            CreateMap<Proveedor, ProveedorDto>();
            CreateMap<ProveedorDto, Proveedor>();
            
        }
    }
}
