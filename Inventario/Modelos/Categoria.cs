namespace Inventario.Modelos
{
    public class Categoria
    {
        public int Id {  get; set; }    
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; set; } = new HashSet<Producto>();
        public ICollection<ProveedorCategoria> ProveedorCategorias { get; set; } = new HashSet<ProveedorCategoria>();
    }
}
