using ApiProductos.Dto.Request;
using ApiProductos.Dto.Response;
using ApiProductos.Entity;
using ApiProductos.Model;

namespace ApiProductos.Mappers.Interface
{
    public interface IMapperEntityProductos
    {
        ModelProductos ToModel(EntityProductos entity);
        EntityProductos ToEntity(ModelProductos model);
    }
}
