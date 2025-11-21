using ApiProductos.Entity;

namespace ApiProductos.Data.Repository.Interface
{
    public interface IRepositoryProductos
    {
        EntityProductos get(int ID);
        EntityProductos post(EntityProductos entity);
        EntityProductos put(EntityProductos entity);
        void delete(int ID);
        List<EntityProductos> GetList();
    }
}
