using System.ComponentModel.DataAnnotations;

namespace ApiProductos.Entity
{
    public class EntityProductos
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Valor { get; set; }
    }
}
