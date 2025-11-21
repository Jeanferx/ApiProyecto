using System.ComponentModel.DataAnnotations;

namespace ApiProductos.Dto.Request
{
    public class RequestProductos
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}
