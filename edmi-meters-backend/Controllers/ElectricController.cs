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
    public class ElectricController : ControllerBase
    {
        private EdmiMeterDBContext dbContext;
        private List<ElectricMeter> electricMeterList = null;

        public ElectricController(EdmiMeterDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<ElectricMeter> GetElectric()
        {
            return dbContext.ElectricMeter.ToList();
        }    

        [HttpGet("{Serial:int}")]
        public IEnumerable<ElectricMeter> GetElectricBySerial(int serial)
        {
            return dbContext.ElectricMeter.Where(meter => meter.Serial == serial).ToList();
        }

        [HttpPost]
        public async Task<ActionResult<ElectricMeter>> SetElectric(ElectricMeter electricMeter)
        {
            try
            {
                if (electricMeter == null)
                    return BadRequest();

                electricMeter.Id = GetElectric().Count() + 1;
                var electricSeted = await dbContext.ElectricMeter.AddAsync(electricMeter);
                await dbContext.SaveChangesAsync();
                return StatusCode(200, "Success");
            }
            catch(Exception)
            {
                return StatusCode(500, "Error retrieving data from the database");
            }
        }
    }
}
