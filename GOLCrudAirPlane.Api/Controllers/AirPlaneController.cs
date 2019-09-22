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
        public IEnumerable<Airplane> Get()
        {
            return _appAirplane.List();
        }

        // GET: api/Airplane/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Airplane> Get(Guid id)
        {
            return await _appAirplane.GetEntity(id);
        }

        // POST: api/Airplane
        [HttpPost]
        public void Post([FromBody] Airplane Airplane)
        {
            _appAirplane.Add(Airplane);
        }

        // PUT: api/Airplane/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Airplane Airplane)
        {
            _appAirplane.Update(Airplane);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete([FromBody] Airplane Airplane)
        {
            _appAirplane.Delete(Airplane);
        }
    }
}
