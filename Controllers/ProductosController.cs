using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProductos.Data;
using APIProductos.Models;
using APIProductos.Repository;
using APIProductos.Models.Dto;

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        protected ResponseDto _responseDto;


        public ProductosController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
            _responseDto= new ResponseDto();
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            try
            {
                var listaProductos = await _productoRepository.GetProductos();
                _responseDto.Result = listaProductos;
                _responseDto.DisplayMessage = "Lista de Productos.";
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = "Error al repuperar los Productos.";
                _responseDto.ErrorMessage= new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
            
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            try
            {
                var producto = await _productoRepository.GetProductoById(id);
                if (producto == null)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.DisplayMessage = "El Producto no Existe.";
                    return NotFound(_responseDto);
                }
                else
                {
                    _responseDto.Result = producto;
                    _responseDto.DisplayMessage = "Informacion del Producto.";
                }
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = "Error al recuperar la informacion del producto con codigo: "+ id;
                _responseDto.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
            
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(ProductoDto productoDto)
        {
            try
            {
                ProductoDto producto = await _productoRepository.CreateUpdateProducto(productoDto);
                _responseDto.Result = producto;
                _responseDto.DisplayMessage = "Producto Actualizado Correctamente.";
                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = "Error al actualizar el producto con codigo: " + productoDto.Codigo;
                _responseDto.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
        }

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(ProductoDto productoDto)
        {
            try
            {
                ProductoDto producto = await _productoRepository.CreateUpdateProducto(productoDto);
                _responseDto.Result = producto;
                _responseDto.DisplayMessage = "Producto Agregado Correctamente.";
                return CreatedAtAction("GetProducto", new { id = producto.Codigo }, _responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = "Error al agregar nuevo producto.";
                _responseDto.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
            
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                bool estaEliminado = await _productoRepository.DeleteProducto(id);
                if (estaEliminado)
                {
                    _responseDto.Result = estaEliminado;
                    _responseDto.DisplayMessage = "Producto Eliminado";
                    return Ok(_responseDto);
                }
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = "Error al eliminar el producto con codigo: "+id;
                return BadRequest(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = "Error al eliminar el producto con codigo: " + id;
                _responseDto.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_responseDto);
            }
        }

    }
}
