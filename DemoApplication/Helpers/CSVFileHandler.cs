#region (c) 2024 Adam Melhem All right reserved
//   Author     : Adam Melhem
//   Projet     : ClearCut
//   Created    : 26.4.2024
#endregion

using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

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

        public ICollection<TestLine> LoadDataFromSelectedZipFileFlow()
        {
            var fileNamePath = this.GetOpenFileDialogPathName();
            var csvFile = ExtractToDirectory(fileNamePath);
            return readCSVFile(csvFile.FullName);
        }

        public override FileInfo GetOpenFileDialogPathName()
             => base.GetOpenFileDialogPathName(fileFilter);

        private ICollection<TestLine> readCSVFile(string csvFile)
        {
            var dataWithHeader = File.ReadAllLines(csvFile);
            var data = dataWithHeader.Skip(1).ToList();
            var testLines = new List<TestLine>();
            foreach (var line in data)
            {
                var lineValues = line.Split(',');
                var x = lineValues[0];
                var y = lineValues[1];
                var prediction = bool.Parse(lineValues[2]);
                testLines.Add(new TestLine(x, y, prediction));
            }
            return testLines;
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
