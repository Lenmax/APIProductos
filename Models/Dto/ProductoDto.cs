using Microsoft.EntityFrameworkCore;

namespace APIProductos.Models.Dto
{
    public class ProductoDto
    {
        public int Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Marca { get; set; }
        public decimal? Precio { get; set; }
        public string? Imagen { get; set; }
    }
}
