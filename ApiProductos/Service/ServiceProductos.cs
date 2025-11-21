using ApiProductos.Data.Repository;
using ApiProductos.Data.Repository.Interface;
using ApiProductos.Entity;
using ApiProductos.Mappers.Interface;
using ApiProductos.Model;
using ApiProductos.Service.Interface;

namespace ApiProductos.Service
{
    public class ServiceProductos : IServiceProductos
    {
        private readonly IRepositoryProductos _repository;
        private readonly IMapperEntityProductos _mapper;

        public ServiceProductos(IRepositoryProductos repositoryProductos, IMapperEntityProductos mapperEntityProductos)
        {
            _repository=repositoryProductos;
            _mapper=mapperEntityProductos;

        }
        public bool delete(int ID)
        {
            EntityProductos entity = _repository.get(ID);
            if (entity == null)
            {
                return false;
            }
            _repository.delete(ID);
            return true;
        }


        public ModelProductos get(int ID)
        {
            EntityProductos entity = _repository.get(ID);
            return _mapper.ToModel(entity);
        }

        public List<ModelProductos> GetList()
        {
            var entities = _repository.GetList();
            return entities.Select(e => new ModelProductos
            {
                Description = e.Description,
                Id = e.Id,
                Name = e.Name,
                Valor=e.Valor,
            }).ToList();
        }

        public ModelProductos post(ModelProductos model)
        {
            EntityProductos entity= _mapper.ToEntity(model);
            _repository.post(entity);
            return _mapper.ToModel(entity);
        }

        public ModelProductos put(int ID, ModelProductos model)
        {
            EntityProductos entity = _repository.get(ID);
            if (entity == null)
            {
                return null;
            }
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Valor = model.Valor;
            _repository.put(entity);
            return _mapper.ToModel(entity);
        }
    }
}
