using System.Net;
using Microsoft.AspNetCore.Mvc;
using empleadovac.Models;

namespace empleadovac.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class codigotrabajoController : ControllerBase
    {
        IcodigotrabajoService codigotrabajoService;
        public codigotrabajoController(IcodigotrabajoService _codigotrabajoService)
        {
            codigotrabajoService = _codigotrabajoService;
        }

        [HttpPost]
        public async Task<IActionResult> post([FromBody] codigotrabajo newcodigotrabajo)
        {
            await codigotrabajoService.CreateAsync(newcodigotrabajo);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(codigotrabajoService.Get());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] codigotrabajo updcodigotrabajo)
        {
            await codigotrabajoService.Update(id, updcodigotrabajo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await codigotrabajoService.Delete(id);
            return Ok();
        }
    }
}