using Microsoft.AspNetCore.Mvc;
using ProduccionBack.Entities;
using ProduccionBack.Services;

namespace ProduccionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormasPagoController : ControllerBase
    {
        private IAplicacionService service;

        public FormasPagoController()
        {
            service = new AplicacionService();
        }

        // GET: api/<FormasPagoController>
        [HttpGet("formasPago")]
        public IActionResult Get()
        {
            return Ok(service.ConsultarFormasPago());
        }

     
    }
}
