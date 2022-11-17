using APIProductos.Models.Dto;

namespace APIProductos.Repository
{
    public interface IProductoRepository
    {
        Task<List<ProductoDto>> GetProductos();
        Task<ProductoDto> GetProductoById(int id);
        Task<ProductoDto> CreateUpdateProducto(ProductoDto productoDto);
        Task<bool> DeleteProducto(int id);
    }
}