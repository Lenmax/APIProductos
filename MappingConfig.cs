using APIProductos.Models;
using APIProductos.Models.Dto;
using AutoMapper;

namespace APIProductos
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductoDto, Producto>();
                config.CreateMap<Producto, ProductoDto>();
            });

            return mappingConfig;
        }
    }
}
