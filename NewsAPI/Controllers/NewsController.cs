using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewsAPI.Controllers
{
    public class NewsController : Controller
    {
        public NewsController(INewsProvider provider)
        {
            _newsProvider = provider;
        }

        [HttpGet("api/news")]
        public IActionResult GetNews()
        {
            return Ok(_newsProvider.GetNewsItems());
        }

        private readonly INewsProvider _newsProvider;
    }
}