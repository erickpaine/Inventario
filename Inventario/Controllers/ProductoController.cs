using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Inventario.Data;
using Inventario.Modelos;
using Inventario.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase

    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductos()
        {
           var productos = await _context.Productos.ToListAsync();
            var productosDto = _mapper.Map<List<ProductoDto>>(productos);
            return Ok(productosDto);
        }
        [HttpPost]
        public async Task<ActionResult<ProductoDto>> CrearProducto(ProductoDto productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto);

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            await _context.Entry(producto).Reference(p => p.Categoria).LoadAsync();
            await _context.Entry(producto).Reference(p => p.Proveedor).LoadAsync();

            var productoCreado = _mapper.Map<ProductoDto>(producto);

            return Ok(productoCreado);
        }

        
    }
}
