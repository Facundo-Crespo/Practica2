using Microsoft.AspNetCore.Mvc;
using ProduccionBack.Entities;
using ProduccionBack.Services;

namespace ProduccionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private IAplicacionService service;

        public FacturasController()
        {
            service = new AplicacionService();
        }

        // GET: api/<FacturasController>
        [HttpGet("facturas")]
        public IActionResult Get()
        {
            return Ok(service.ConsultarFacturas());
        }    

        //POST api/<FacturasController>
        [HttpPost]
        public IActionResult Post([FromQuery] Factura factura, [FromQuery] int idArticulo, [FromQuery] int cantidad)
        {
            try
            {
                if (factura == null)
                {
                    return BadRequest("Se esperaba una orden de producción completa");
                }
                if (service.RegistrarFactura(factura, idArticulo, cantidad))
                    return Ok("Factura registrada con éxito!");
                else
                    return StatusCode(500, "No se pudo registrar!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente nuevamente!");
            }
        }
    }
}
