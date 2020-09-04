using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
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

        [HttpPost]
        public List<object> Post(ScreeningResult screeningResult)
        {
            GoogleCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            /*
            var range = $"{SheetName}!A:C";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;
            */

            screeningResult.Date = DateTime.Now;

            var range = $"{SheetName}!A:D";
            var valueRange = new ValueRange();

            var objectList = new List<object>() { screeningResult.Date.ToShortDateString(), screeningResult.Date.ToShortTimeString(), screeningResult.Name, screeningResult.Risk };
            valueRange.Values = new List<IList<object>> { objectList };

            var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendResponse = appendRequest.Execute();

            return objectList;
        }

        private void CreateEntry()
        {

        }

    }
}
