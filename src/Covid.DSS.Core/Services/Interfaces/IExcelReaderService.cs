using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Covid.DSS.Common.Models;
using Covid.DSS.Common.Models.DTO;

namespace Covid.DSS.Core.Services.Interfaces
{
    public interface IExcelReaderService
    {
        IEnumerable<HospitalMetric> ParseFile(byte[] file, int templateId, HospitalTemplateSetup setup);
    }
}
