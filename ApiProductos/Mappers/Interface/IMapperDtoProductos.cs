using ApiProductos.Dto.Request;
using ApiProductos.Dto.Response;
using ApiProductos.Model;

namespace ApiProductos.Mappers.Interface
{
    public interface IMapperDtoProductos
    {
        ModelProductos ToModel(RequestProductos dto);
        ResponseProductos ToDto(ModelProductos model);
    }
}
