using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DriverServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        static List<Driver> drivers = new List<Driver>()
        {
            new Driver(){DriverId=1, DriverName="Raj", Age=20, Contact=9988776655, VehicleNo="KA00XX0000" },
            new Driver(){DriverId=2, DriverName="Vishal", Age=22, Contact=9988776655, VehicleNo="KA01XX0001" },
            new Driver(){DriverId=3, DriverName="Vivek", Age=25, Contact=9988776655, VehicleNo="KA02XX0002" },
            new Driver(){DriverId=4, DriverName="Amit", Age=30, Contact=9988776655, VehicleNo="KA03XX0003" },
        };

        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            return drivers;
        }

        [HttpGet("{id}")]
        public Driver Get(int id)
        {
            return drivers.Find(item=>item.DriverId==id);
        }

        [HttpPost]
        public IEnumerable<Driver> Post([FromBody] Driver driver)
        {
            drivers.Add(driver);
            return drivers;
        }

        [HttpPut("{id}")]
        public IEnumerable<Driver> Put(int id, [FromBody] Driver driver)
        {
            int n = drivers.FindIndex(item => item.DriverId == id);
            drivers[n] = driver;
            return drivers;
        }
    }
}
