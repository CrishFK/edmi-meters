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
    public class WaterController : ControllerBase
    {
        private EdmiMeterDBContext dbContext;

        public WaterController(EdmiMeterDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<WaterMeter> GetWater()
        {
            return dbContext.WaterMeter.ToList();
        }

        [HttpGet("{Serial:int}")]
        public IEnumerable<WaterMeter> GetWaterBySerial(int serial)
        {
            return dbContext.WaterMeter.Where(meter => meter.Serial == serial).ToList();
        }

        [HttpPost]
        public async Task<ActionResult<WaterMeter>> SetWater(WaterMeter waterMeter)
        {
            try
            {
                if (waterMeter == null)
                    return BadRequest();

                waterMeter.Id = GetWater().Count() + 1;
                var waterSeted = await dbContext.WaterMeter.AddAsync(waterMeter);
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
