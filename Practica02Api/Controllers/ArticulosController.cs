using Microsoft.AspNetCore.Mvc;
using ProduccionBack.Entities;
using ProduccionBack.Services;

namespace ProduccionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IAplicacionService service;

        public ArticulosController()
        {
            service = new AplicacionService();
        }

        // GET: api/<ArticulosController>
        [HttpGet("articulos")]
        public IActionResult Get()
        {
            return Ok(service.ConsultarArticulos());
        }

    }
}
