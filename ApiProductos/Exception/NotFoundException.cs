namespace ApiProductos.Exception
{
    public class NotFoundException : FormatException
    {
        public NotFoundException()
        : base("El recurso solicitado no fue encontrado.") // mensaje por defecto
        {
        }

        public NotFoundException(string message) : base()
        {//PARA PERSONALISAR
        }
    }
}
