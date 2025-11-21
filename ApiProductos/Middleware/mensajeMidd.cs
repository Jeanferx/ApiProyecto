using ApiProductos.Exception;
using System.Net;
using System.Text.Json;

namespace ApiProductos.Middleware
{
    public class mensajeMidd
    {
        private readonly RequestDelegate _next;

        public mensajeMidd(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json";
                var response = new { mensaje = ex.Message };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
           
        }
    }
}
