using System;
using Microsoft.AspNetCore.Mvc;

namespace RailwayElf.Controllers
{
    [Produces("application/json")]
    [Route("api/tickets")]
    public class TicketsController : Controller
    {
        // GET: api/tickets
        [HttpGet]
        public IActionResult Get()
        {
            var bookChecker = new TicketsChecker();
            var response = bookChecker.checkTickets().Result;
            return Ok(response);
        }

        // GET: api/Tickets/29.01.2018
        [HttpGet("{stationFrom}/{stationTill}/{depDate}", Name = "GetStation")]
        public IActionResult GetStation(String stationFrom, String stationTill, String depDate)
        {       
            var bookChecker = new TicketsChecker();
            var stationFromLink = bookChecker.findStation(stationFrom).Result;
            var stationTillLink = bookChecker.findStation(stationTill).Result;
            if (stationFromLink == null || stationTillLink == null)
            {
                return NotFound();
            }

            var response = bookChecker.checkTickets(stationFromLink, stationTillLink, depDate).Result;
            return Ok(response);
        }
    }
}
