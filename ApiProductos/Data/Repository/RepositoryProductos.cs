using ApiProductos.Data.Context;
using ApiProductos.Data.Repository.Interface;
using ApiProductos.Entity;

namespace ApiProductos.Data.Repository
{
    public class RepositoryProductos : IRepositoryProductos
    {
        private readonly ContextProductos _context;
        public RepositoryProductos(ContextProductos context)
        {
            _context=context;
        }

        public void delete(int ID)
        {
            EntityProductos entity = _context.Productos.Find(ID);
            if (entity != null)
            {
                _context.Productos.Remove(entity);
                _context.SaveChanges();
            }
        }


        public EntityProductos get(int ID)
        {
            EntityProductos entity = _context.Productos.Find(ID);
            if (entity!=null)
            {
                return entity;
            }
            return null;
        }

        public List<EntityProductos> GetList()
        {
            return _context.Productos.ToList();
        }

        public EntityProductos post(EntityProductos entity)
        {
            _context.Productos.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public EntityProductos put(EntityProductos entity)
        {
            _context.Productos.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
