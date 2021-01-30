using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.DSS.Common.Configuration;
using Covid.DSS.Common.Models;
using Covid.DSS.Common.Models.DTO;
using Covid.DSS.Core.Services.Interfaces;
using OfficeOpenXml;

namespace Covid.DSS.Core.Services
{
    public class ExcelReaderService : IExcelReaderService
    {
        private ExcelWorksheet _sheet;
        private HospitalTemplateSetup _setup;

        private readonly ExcelSettings _excelSettings;
        
        protected const string EffectiveDateCode = "EFFECTIVEDATE";
        protected const string UnitIdCode = "UNITID";
        protected const string SignatureCode = "DOCSIGNATURE";
        protected readonly string[] _excludedMetrics = { EffectiveDateCode, UnitIdCode, SignatureCode };

        protected readonly string Culture = "el-GR";

        public ExcelReaderService(ExcelSettings excelSettings)
        {
            _excelSettings = excelSettings;
        }

        /// <summary>
        /// Parses a excel file given a set of setup instructions into a collection
        /// of <see cref="HospitalMetric"/>s
        /// </summary>
        /// <param name="file">The file to parse</param>
        /// <param name="setup">The setup instructions</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="HospitalMetric"/></returns>
        public IEnumerable<HospitalMetric> ParseFile(byte[] file, HospitalTemplateSetup setup)
        {
            _setup = setup;

            // Read excel
            var package = CreatePackageFromFile(file);
            _sheet = GetWorksheet(package);
            
            // Iterate through metric setups and read cells
            var metricValuesList = new Dictionary<string, IEnumerable<string>>();
            var metrics = new List<HospitalMetric>();

            foreach (var metricSetup in _setup.MetricSetups)
            {
                var metricValues = ProcessMetricSetup(metricSetup);
                metricValuesList.Add(metricSetup.MetricType.Code, metricValues);
            }

            DateTime.TryParse(metricValuesList[EffectiveDateCode].FirstOrDefault(), new CultureInfo(Culture),
                DateTimeStyles.None, out var effectiveDate);
            var unitIdList = metricValuesList[UnitIdCode].ToList();
            var signature = metricValuesList[SignatureCode].FirstOrDefault();

            if (!IsSignatureValid(signature))
                return null;

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

        /// <summary>
        /// Extracts cell values from <see cref="ExcelWorksheet"/> based on setup instructions
        /// </summary>
        /// <param name="metricSetup">The setup instruction object</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="string"/></returns>
        private IEnumerable<string> ProcessMetricSetup(HospitalTemplateMetricSetup metricSetup)
        {
            if (_sheet == null)
                throw new ArgumentNullException(nameof(_sheet));

            var result = new List<string>();

            switch (metricSetup.SourceType)
            {
                case DataTemplateMetricSourceType.Cell:
                    result.Add(_sheet.Cells[metricSetup.Source].GetValue<string>());
                    break;
                case DataTemplateMetricSourceType.Range:
                    result.AddRange(ExtractValues(_sheet.Cells[metricSetup.Source]));
                    break;
                case DataTemplateMetricSourceType.Field:
                    result.AddRange(ExtractValues(_sheet.Workbook.Names[metricSetup.Source]));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        /// <summary>
        /// Extracts the cell values of an <see cref="ExcelRangeBase"/> to a
        /// collection of strings
        /// </summary>
        /// <param name="range">The range to extract cell values from</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="string"/></returns>
        private IEnumerable<string> ExtractValues(ExcelRangeBase range)
            => range.Select(cell => cell.GetValue<string>()).ToList();

        /// <summary>
        /// Checks whether the claimed signature string matches the accepted signature
        /// </summary>
        /// <param name="claimedSignature">The signature to verify</param>
        private bool IsSignatureValid(string claimedSignature)
            => claimedSignature == _excelSettings.Signature;
    }
}
