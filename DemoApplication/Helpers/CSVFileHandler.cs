#region (c) 2024 Adam Melhem All right reserved
//   Author     : Adam Melhem
//   Projet     : ClearCut
//   Created    : 26.4.2024
#endregion

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace ClearCut.Helpers
{
    internal class CSVFileHandler : FileHandler
    {
        const string fileFilter = "ZIP files (*.zip)|*.zip|CSV files (*.csv)|*.csv";
        readonly string _tempFolder;

        public CSVFileHandler()
        {
            _tempFolder = Path.GetTempPath();
        }

        public async Task<ICollection<TestLine>> LoadDataFromSelectedZipFileFlow()
        {
            var fileNamePath = this.GetOpenFileDialogPathName();
            var csvFile = ExtractToDirectory(fileNamePath);
            return await readCSVFile(csvFile.FullName);
        }

        public override FileInfo GetOpenFileDialogPathName()
             => base.GetOpenFileDialogPathName(fileFilter);

        private async Task<ICollection<TestLine>> readCSVFile(string csvFile)
        {
            var testLines = new ConcurrentBag<TestLine>();
            using (var reader = new StreamReader(csvFile))
            {
                var dataWithHeader = await reader.ReadToEndAsync();
                var data = dataWithHeader.
                         Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                         .ToList().Skip(1).ToList();
                Parallel.ForEach(data, (line) =>
                {
                    var lineValues = line.Split(',');
                    var x = lineValues[0];
                    var y = lineValues[1];
                    var prediction = bool.Parse(lineValues[2]);
                    testLines.Add(new TestLine(x, y, prediction));
                });
            }
            return testLines.ToList();
        }

        // TODO: make search mechanism to get the actual csv file name without assumbtion
        private FileInfo ExtractToDirectory(FileInfo fileNamePath)
        {
            var newExtractedFileName = fileNamePath.Name.Split('.').FirstOrDefault() + ".csv";
            var newExtractedFileInfo = new FileInfo(Path.Combine(_tempFolder, newExtractedFileName));
            if (File.Exists(newExtractedFileInfo.FullName))
            {
                File.Delete(newExtractedFileInfo.FullName);
            }
            ZipFile.ExtractToDirectory(fileNamePath.FullName, newExtractedFileInfo.DirectoryName);
            return newExtractedFileInfo;
        }

    }
}
