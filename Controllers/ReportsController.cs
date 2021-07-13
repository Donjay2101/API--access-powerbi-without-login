using API.PowerBI.Models;
using API.PowerBI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace API.PowerBI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ILogger<ReportsController> _logger;
        private readonly IPowerBIService _powerBIService;
        public ReportsController(ILogger<ReportsController> logger, IPowerBIService powerBIService)
        {
            _logger = logger;
            _powerBIService = powerBIService;
        }

        /// GET: api/<ReportController>
        /// <summary>
        /// Workspace ID: this is the powerBI workspace ID.
        /// Report ID: powerBI report ID.
        /// </summary>
        /// <returns>
        ///     {
        ///         Embeded Url,
        ///         embdedAccessToken,
        ///         reportID
        ///     }
        /// </returns>
        [HttpGet("GetReport")]
        public async Task<IActionResult> GetReport(string input)
        {
            var reportInput = JsonConvert.DeserializeObject<ReportInput>(input);
            var report = await _powerBIService.GetReport(reportInput);
            return Ok(report);
        }


        // GET: api/<ReportController>
        [HttpGet]
        public string Get()
        {
            return "API is running";
        }
    }
}
