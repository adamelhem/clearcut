using System.IO;

namespace ClearCut.Helpers
{
    internal interface IFileHandler
    {
        FileInfo GetOpenFileDialogPathName();
        FileInfo GetOpenFileDialogPathName(string filter);
    }
}