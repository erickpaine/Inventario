using AutoMapper;
using Inventario.Dto;
using Inventario.Modelos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Inventario.Profiles
{
    public class CategoriaProfile: Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CategoriaDto, Categoria>();
            CreateMap<Categoria, CategoriaDto>();
        }
    }
}
