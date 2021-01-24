using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Common.Models.DTO;

namespace Covid.DSS.Core.Services.Interfaces
{
    public interface IExcelReaderService
    {
        void Import(byte[] file, int templateId);
    }
}
