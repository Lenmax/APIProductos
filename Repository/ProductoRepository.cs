using APIProductos.Data;
using APIProductos.Models;
using APIProductos.Models.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDBContext _appDBContext;
        private IMapper _mapper;

        public ProductoRepository(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task<ProductoDto> CreateUpdateProducto(ProductoDto productoDto)
        {
            Producto producto = _mapper.Map<ProductoDto,Producto>(productoDto);
            if(producto.Codigo>0) _appDBContext.Productos.Update(producto);
            else await _appDBContext.Productos.AddAsync(producto);
            await _appDBContext.SaveChangesAsync();
            return _mapper.Map<Producto,ProductoDto>(producto);

        }

        public async Task<bool> DeleteProducto(int id)
        {
            try
            {
                Producto? producto = await _appDBContext.Productos.FindAsync(id);
                if (producto == null) return false;
                _appDBContext.Productos.Remove(producto);
                await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductoDto> GetProductoById(int id)
        {
            Producto? producto = await _appDBContext.Productos.FindAsync(id);

            return _mapper.Map<ProductoDto>(producto);
        }

        public async Task<List<ProductoDto>> GetProductos()
        {
            List<Producto> listaProductos = await _appDBContext.Productos.ToListAsync();

            return _mapper.Map<List<ProductoDto>>(listaProductos);
        }
    }
}
