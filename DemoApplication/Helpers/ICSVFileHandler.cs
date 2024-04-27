using ClearCut.Model;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ClearCut.Helpers
{
    public interface ICSVFileHandler
    {
        FileInfo GetOpenFileDialogPathName();
        Task<ICollection<TestLine>> LoadDataFromSelectedZipFileFlow();
    }
}