using System.Net;
using Microsoft.AspNetCore.Mvc;
using empleadovac.Models;

namespace empleadovac.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class cargoController : ControllerBase
    {
        IcargoService cargoService;
        public cargoController(IcargoService _cargoService)
        {
            cargoService = _cargoService;
        }

        [HttpPost]
        public async Task<IActionResult> post([FromBody] cargo newcargo)
        {
            await cargoService.CreateAsync(newcargo);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(cargoService.Get());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] cargo updcargo)
        {
            await cargoService.Update(id, updcargo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await cargoService.Delete(id);
            return Ok();
        }
    }
}