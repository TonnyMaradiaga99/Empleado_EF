using System.Net;
using Microsoft.AspNetCore.Mvc;
using empleadovac.Models;

namespace empleadovac.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class vacacionesController : ControllerBase
    {
        IvacacionesService vacacionesService;
        public vacacionesController(IvacacionesService _vacacionesService)
        {
            vacacionesService = _vacacionesService;
        }

        [HttpPost]
        public async Task<IActionResult> post([FromBody] vacaciones newvacaciones)
        {
            await vacacionesService.CreateAsync(newvacaciones);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(vacacionesService.Get());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] vacaciones updvacaciones)
        {
            await vacacionesService.Update(id, updvacaciones);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await vacacionesService.Delete(id);
            return Ok();
        }
    }
}