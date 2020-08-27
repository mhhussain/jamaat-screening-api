using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace jamaat_screening_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreeningController : ControllerBase
    {
        private readonly ILogger<ScreeningController> _logger;

        public ScreeningController(ILogger<ScreeningController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "pong";
        }
    }
}
