using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Covid.DSS.Attributes;
using Covid.DSS.Common.Utilities;
using Covid.DSS.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Covid.DSS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Covid.DSS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMetricService _metricService;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IMetricService metricService, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _metricService = metricService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost, Authorize]
        [AllowedFileExtensions(".xlsx")]
        public async Task<IActionResult> ImportRequest(IFormFile file, [FromForm] int templateId)
        {
            await _metricService.Import(file.ToByteArray(), templateId);
            return Ok();
        }
    }
}
