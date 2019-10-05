using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOLCrudAirplane.Application;
using GOLCrudAirplane.Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GOLCrudAirplane.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneController : ControllerBase
    {
        private readonly IAppAirplane _appAirplane;

        public AirplaneController(IAppAirplane appAirplane)
        {
            _appAirplane = appAirplane;
        }

        // GET: api/Airplane
        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_appAirplane.List());
        }

        // GET: api/Airplane/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var Airplane = await _appAirplane.GetEntity(id);

            if (Airplane == null)
            {
                return NotFound();
            }

            return Ok(Airplane);
        }

        // POST: api/Airplane/incluir
        [HttpPost]
        public ActionResult<Airplane> PostAirplane([FromBody]Airplane airplane)
        {
            if (airplane != null)
            {
                airplane.CriadoEm = DateTime.Now.Date;
            }
            var retorno = _appAirplane.Add(airplane);
            return Ok(retorno);
        }

        // PUT: api/Airplane/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Airplane airplane)
        {
            var retorno = _appAirplane.Update(airplane);
            return Ok(retorno);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var retorno = _appAirplane.Delete(id);
            return Ok(retorno);
        }
    }
}
