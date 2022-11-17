using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIProductos.Models
{
    public class Producto
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public string? Marca { get; set;}
        [Required]
        [Precision(18,2)]
        public decimal? Precio { get; set; }
        public string? Imagen { get; set; }
    }
}
