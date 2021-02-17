using edmi_meters_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edmi_meters_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private EdmiMeterDBContext dbContext;

        public GatewayController(EdmiMeterDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Gateways> GetGateway()
        {
            return dbContext.Gateways.ToList();
        }

        [HttpGet("{serial:int}")]
        public IEnumerable<Gateways> GetGatewayBySerial(int serial)
        {
            return dbContext.Gateways.Where(gateway => gateway.Serial == serial).ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Gateways>> SetElectric(Gateways gateways)
        {
            try
            {
                if (gateways == null)
                    return BadRequest();

                gateways.Id = GetGateway().Count() + 1;
                var electricSeted = await dbContext.Gateways.AddAsync(gateways);
                await dbContext.SaveChangesAsync();
                return StatusCode(200, "Success");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error retrieving data from the database");
            }
        }
    }
}
