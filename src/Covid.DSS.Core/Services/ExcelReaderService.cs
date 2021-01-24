using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.DSS.Common.Models;
using Covid.DSS.Common.Models.DTO;
using Covid.DSS.Core.Services.Interfaces;
using OfficeOpenXml;
using ValueType = Covid.DSS.Common.Models.ValueType;

namespace Covid.DSS.Core.Services
{
    public class ExcelReaderService : IExcelReaderService
    {
        private ExcelWorksheet _sheet;
        private HospitalTemplateSetup _setup;

        private readonly string[] _excludedMetrics = {"EFFECTIVEDATE", "UNITID"};

        public IEnumerable<HospitalMetric> ParseFile(byte[] file, int templateId, HospitalTemplateSetup setup)
        {
            _setup = setup;

            // read excel
            var package = CreatePackageFromFile(file);
            _sheet = GetWorksheet(package);

            var startingRow = _setup.HeaderRows + 1;

            //TODO: validate file KEY

            // iterate through metric setups and read cells
            var metricValuesList = new Dictionary<string, IEnumerable<string>>();
            var metrics = new List<HospitalMetric>();

            foreach (var metricSetup in _setup.MetricSetups)
            {
                var metricValues = ProcessMetricSetup(metricSetup);
                metricValuesList.Add(metricSetup.MetricType.Code, metricValues);
            }

            DateTime.TryParse(metricValuesList["EFFECTIVEDATE"].FirstOrDefault(), new CultureInfo("el-GR"), DateTimeStyles.None, out var effectiveDate);
            var unitIdList = metricValuesList["UNITID"].ToList();

            foreach (var list in metricValuesList)
            {
                if(_excludedMetrics.Contains(list.Key))
                    continue;

                var index = 0;

                foreach (var metricValue in list.Value)
                {
                    var metricSetup = _setup.MetricSetups.FirstOrDefault(x => x.MetricType.Code == list.Key);

                    if(metricSetup == null)
                        continue;

                    var unitIdParsed = int.TryParse(unitIdList[index], out var unitId);

                    if(!unitIdParsed)
                        continue;

                    var metric = new HospitalMetric
                    {
                        UnitId = unitId,
                        TypeId = metricSetup.MetricTypeId,
                        Value = metricValue,
                        EffectiveDate = effectiveDate,
                    };

                    metrics.Add(metric);

                    index++;
                }
            }

            return metrics;
        }

        /// <summary>
        /// Creates an <see cref="ExcelPackage"/> from a byte array
        /// </summary>
        /// <param name="file">The file to read</param>
        /// <returns>An <see cref="ExcelPackage"/></returns>
        private ExcelPackage CreatePackageFromFile(byte[] file)
        {
            if(file == null)
                throw new ArgumentNullException(nameof(file));

            var stream = new MemoryStream(file, false);
            return new ExcelPackage(stream);
        }

        /// <summary>
        /// Retrieves the a worksheet
        /// </summary>
        /// <param name="package">The <see cref="ExcelPackage"/> to retrieve the <see cref="ExcelWorksheet"/> from</param>
        /// <param name="name">The optional <see cref="ExcelWorksheet"/> name to search for</param>
        /// <returns>An <see cref="ExcelWorksheet"/></returns>
        private ExcelWorksheet GetWorksheet(ExcelPackage package, string name = null)
        {
            if (package == null)
                throw new ArgumentNullException(nameof(package));

            return name == null 
                ? package.Workbook.Worksheets.FirstOrDefault()
                : package.Workbook.Worksheets.FirstOrDefault(x => x.Name == name);
        }

        private IEnumerable<string> ProcessMetricSetup(HospitalTemplateMetricSetup metricSetup)
        {
            if (_sheet == null)
                throw new ArgumentNullException(nameof(_sheet));

            var result = new List<string>();

            var cells = _sheet.Cells[metricSetup.Source];

            foreach (var cell in cells)
            {
                var value = cell.GetValue<string>();
                result.Add(value);
            }

            return result;
        }
    }
}
