namespace Inventario.Dto
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaId { get; set; }
        public int ProveedorId { get; set; }
    }
}
