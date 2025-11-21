using ApiProductos.Entity;
using ApiProductos.Mappers.Interface;
using ApiProductos.Model;

namespace ApiProductos.Mappers
{
    public class MapperEntityProductos : IMapperEntityProductos
    {
        public EntityProductos ToEntity(ModelProductos model)
        {
            return new EntityProductos
            {
                Description = model.Description,
                Id = model.Id,
                Name = model.Name,
                Valor = model.Valor,
            };
        }

        public ModelProductos ToModel(EntityProductos entity)
        {
            return new ModelProductos
            {
                Description = entity.Description,
                Id = entity.Id,
                Name = entity.Name,
                Valor = entity.Valor,
            };
        }
    }
}
