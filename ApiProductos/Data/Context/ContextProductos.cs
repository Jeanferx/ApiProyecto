using ApiProductos.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiProductos.Data.Context
{
    public class ContextProductos:DbContext
    {
        public ContextProductos(DbContextOptions<ContextProductos> options) : base(options) { }

        public DbSet<EntityProductos> Productos { get; set; }
    }
}
