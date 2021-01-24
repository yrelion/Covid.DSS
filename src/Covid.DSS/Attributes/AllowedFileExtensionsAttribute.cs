using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid.DSS.Common.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Covid.DSS.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class AllowedFileExtensionsAttribute : Attribute, IActionFilter
    {
        private List<string> AllowedExtensions { get; }

        public AllowedFileExtensionsAttribute(string fileExtensions)
        {
            AllowedExtensions = fileExtensions.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            IEnumerable<IFormFile> files = context.HttpContext.Request.Form.Files;

            foreach (var file in files)
            {
                if (!AllowedExtensions.Any(x => file.FileName.ToLowerInvariant().EndsWith(x)))
                {
                    context.ModelState.AddModelError($"{file.FileName}", Resource.Internal.Errors.UnsupportedFileType.FormatWith($"{string.Join(", ", AllowedExtensions)}"));
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
