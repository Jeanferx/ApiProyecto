using ApiProductos.Dto.Request;
using ApiProductos.Dto.Response;
using ApiProductos.Entity;
using ApiProductos.Mappers.Interface;
using ApiProductos.Model;

namespace ApiProductos.Mappers
{
    public class MapperdtoProductos : IMapperDtoProductos
    {
        ResponseProductos IMapperDtoProductos.ToDto(ModelProductos model)
        {
            return new ResponseProductos
            {
                Description = model.Description,
                Id = model.Id,
                Name = model.Name,
                Valor = model.Valor,
            };
        }

        ModelProductos IMapperDtoProductos.ToModel(RequestProductos dto)
        {
            return new ModelProductos
            {
                Description = dto.Description,
                Name = dto.Name,
                Valor = dto.Valor,
            };
        }
    }
}
