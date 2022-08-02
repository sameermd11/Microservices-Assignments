using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CountryController : ApiController
    {
        static List<Country> cList = new List<Country>()
        {
            new Country{Id=1, CountryName="India", Capital="New Delhi"},
            new Country{Id=2, CountryName="Australia", Capital="Canberra"},
            new Country{Id=3, CountryName="China", Capital="Beijing"},
            new Country{Id=4, CountryName="Japan", Capital="Tokyo"},
        };

        [HttpGet]
        public List<Country> Get()
        {
            return cList;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Country obj = cList.Find(item => item.Id == id);
            if(obj!=null)
            {
                return Ok(obj);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Country obj)
        {
            if(obj!=null)
            {
                cList.Add(obj);
                return Ok(cList);
            }
            else
            {
                return Conflict();
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Country obj)
        {
            if(obj!=null)
            {
                //Country c1 = cList.Find(item => item.Id == obj.Id);
                //cList.Remove(c1);
                //cList.Add(obj);

                cList[id - 1] = obj;
                return Ok(cList);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Country obj = cList.Find(item => item.Id == id);
            if(obj!=null)
            {
                cList.Remove(obj);
                return Ok(cList);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
