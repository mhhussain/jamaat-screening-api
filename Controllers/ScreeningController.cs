using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Services;

namespace jamaat_screening_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreeningController : ControllerBase
    {
        private readonly ILogger<ScreeningController> _logger;

        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };

        private static readonly string ApplicationName = "Jamaat Screening Api";

        private static string SpreadsheetId = "";

        private static string SheetName = "";

        public ScreeningController(ILogger<ScreeningController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "landing";
        }

    }
}
