namespace Inventario.Modelos
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string DireccionEmail { get; set; }
        public ICollection<Producto> Productos { get; set; }
        public ICollection<ProveedorCategoria> ProveedorCategorias { get; set; } = new HashSet<ProveedorCategoria>();
    }
}
