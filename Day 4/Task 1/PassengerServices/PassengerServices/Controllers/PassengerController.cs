using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassengerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        static List<Passenger> passengers = new List<Passenger>()
        {
            new Passenger(){PassengerId=101, PassengerName="Abhi", Age=20, Contact=9988776655, City="Bangalore" },
            new Passenger(){PassengerId=102, PassengerName="Kiran", Age=26, Contact=9988776644, City="Bangalore" },
            new Passenger(){PassengerId=103, PassengerName="Pavan", Age=30, Contact=9988776633, City="Mumbai" },
            new Passenger(){PassengerId=104, PassengerName="Arvind", Age=19, Contact=9988776622, City="Hyderabad" },
            new Passenger(){PassengerId=105, PassengerName="Sam", Age=22, Contact=9988776611, City="Chennai" },
        };

        [HttpGet]
        public IEnumerable<Passenger> Get()
        {
            return passengers; 
        }

        [HttpGet("{id}")]
        public Passenger Get(int id)
        {
            Passenger obj=passengers.Find(item=>item.PassengerId==id);
            return obj;
        }

        [HttpPost]
        public IEnumerable<Passenger> Post([FromBody] Passenger passenger)
        {
            passengers.Add(passenger);
            return passengers;
        }

        [HttpPut("{id}")]
        public IEnumerable<Passenger> Put(int id, [FromBody] Passenger passenger)
        {
            int n=passengers.FindIndex(item => item.PassengerId == id);
            passengers[n] = passenger;
            return passengers;   
        }
    }
}
