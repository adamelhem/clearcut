using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ClearCut.Helpers
{
    internal interface ICSVFileHandler
    {
        FileInfo GetOpenFileDialogPathName();
        Task<ICollection<TestLine>> LoadDataFromSelectedZipFileFlow();
    }
}