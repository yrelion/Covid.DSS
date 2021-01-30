using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid.DSS.Attributes;
using Covid.DSS.Common.Models;
using Covid.DSS.Common.Models.DTO;
using Covid.DSS.Common.Utilities;
using Covid.DSS.Core.Services.Interfaces;
using Indice.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Covid.DSS.Controllers
{
    [Route("[controller]")]
    public class MetricsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMetricService _metricService;
        private readonly UserManager<IdentityUser> _userManager;

        public MetricsController(ILogger<HomeController> logger, IMetricService metricService, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _metricService = metricService;
            _userManager = userManager;
        }

        /// <summary>
        /// Get a list of Metrics
        /// </summary>
        /// <param name="options">The <see cref="ListOptions"/> query string</param>
        /// <returns>A <see cref="ResultSet{T}"/> of <see cref="HospitalMetric"/></returns>
        [HttpGet, Authorize]
        public async Task<IActionResult> GetMetrics(ListOptions<HospitalMetricFilter> options)
        {
            var result = await _metricService.GetMetrics(options);
            return Ok(result);
        }

        /// <summary>
        /// Creates an import request for a template excel file with metrics
        /// </summary>
        /// <param name="file">The file to import</param>
        /// <param name="templateId">The template identifier to parse the file with</param>
        [HttpPost("import"), Authorize]
        [AllowedFileExtensions(".xlsx")]
        public async Task<IActionResult> ImportRequest(IFormFile file, [FromForm] int templateId)
        {
            await _metricService.Import(file.ToByteArray(), templateId);
            return Ok();
        }
    }
}
