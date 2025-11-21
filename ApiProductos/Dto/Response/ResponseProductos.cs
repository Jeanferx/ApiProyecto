using System;

namespace ApiProductos.Dto.Response
{
    public class ResponseProductos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Valor { get; set; }
    }
}
