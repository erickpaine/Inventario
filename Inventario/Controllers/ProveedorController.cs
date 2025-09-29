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
    public class ProveedorController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProveedorController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<ProveedorDto>> CrearProveedor(ProveedorDto proveedorDto)
        {
            var proveedor = _mapper.Map<Proveedor>(proveedorDto);

            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();

            var proveedorCreadoDto = _mapper.Map<ProveedorDto>(proveedor);

            return Ok(proveedorCreadoDto);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedorDto>>> GetProveedor()
        {
            var proveedores = await _context.Proveedores.ToListAsync();
            var proveedorDto = _mapper.Map<List<ProveedorDto>>(proveedores);
            return Ok(proveedorDto);


        }
    }
}
