using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RailwayElf.Controllers
{
    [Produces("application/json")]
    [Route("api/tickets")]
    public class TicketsController : Controller
    {
        // GET: api/tickets
        [HttpGet]
        public SearchResultModel Get()
        {
            var bookChecker = new TicketsChecker();
            var response = bookChecker.checkTickets().Result;
            return response;
        }

        // GET: api/Tickets/5
        [HttpGet("{depDate}", Name = "Get")]
        public SearchResultModel Get(String depDate)
        {
            var bookChecker = new TicketsChecker();
            var response = bookChecker.checkTickets(depDate).Result;
            return response;
        }
        
        // POST: api/Tickets
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
