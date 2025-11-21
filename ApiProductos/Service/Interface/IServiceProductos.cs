using ApiProductos.Entity;
using ApiProductos.Model;

namespace ApiProductos.Service.Interface
{
    public interface IServiceProductos
    {
        ModelProductos get(int ID);
        ModelProductos post(ModelProductos model);
        ModelProductos put(int ID, ModelProductos model);
        bool delete(int ID);
        List<ModelProductos> GetList();
    }
}
