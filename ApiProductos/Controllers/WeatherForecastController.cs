using ApiProductos.Dto.Request;
using ApiProductos.Dto.Response;
using ApiProductos.Mappers.Interface;
using ApiProductos.Model;
using ApiProductos.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ApiProductos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IServiceProductos _service;
        private readonly IMapperDtoProductos _mapper;
        public WeatherForecastController(IServiceProductos serviceProductos, IMapperDtoProductos mapperDtoProductos) { 
            _mapper = mapperDtoProductos;
            _service = serviceProductos;
        }
        [HttpGet("lista-ids")]
        public ActionResult<IEnumerable<string>> GetUsuariosIds()
        {
            var usuarios = _service.GetList();
            var ids = usuarios.Select(u => u.Id).ToList();
            return Ok(ids);
        }
        [HttpGet("{id}")]
        public ActionResult <ModelProductos> Get(int id)
        {
            var user = _service.get(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPost]
        public ActionResult<ResponseProductos> Post([FromBody] RequestProductos dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var model = _mapper.ToModel(dto);
            var created = _service.post(model);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, _mapper.ToDto(created));
        }
        [HttpPut("{id}")]
        public ActionResult<ResponseProductos> Put(int id, [FromBody] RequestProductos dto)
        {
            var model = _mapper.ToModel(dto);
            var updated = _service.put(id, model);
            if (updated == null) return NotFound();
            return Ok(_mapper.ToDto(updated));
        }
        [HttpDelete("{id}")]
        public ActionResult<ModelProductos> Delete(int id)
        {
            var user = _service.delete(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

    }
}
