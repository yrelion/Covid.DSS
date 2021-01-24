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
using Microsoft.AspNetCore.Http;

namespace Covid.DSS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExcelReaderService _excelReaderService;

        public HomeController(ILogger<HomeController> logger, IExcelReaderService excelReaderService)
        {
            _logger = logger;
            _excelReaderService = excelReaderService;
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

        [HttpPost]
        [AllowedFileExtensions(".xlsx")]
        public IActionResult ImportRequest(IFormFile file, [FromForm] int templateId)
        {
            _excelReaderService.Import(file.ToByteArray(), templateId);
            return Ok();
        }
    }
}
