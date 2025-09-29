using AutoMapper;
using Inventario.Data;
using Inventario.Dto;
using Inventario.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategoriaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> CrearCategoria(CategoriaDto categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            var categoriaCreadoDto = _mapper.Map<CategoriaDto>(categoria);

            return Ok(categoriaCreadoDto);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategoria()
        {
            var categorias = await _context.Categorias.ToListAsync();
            var categoriaDto = _mapper.Map<List<CategoriaDto>>(categorias);
            return Ok(categoriaDto);


        }
    }
}
