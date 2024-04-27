using System.IO;
namespace ClearCut.Helpers
{
    public interface IFileHandler
    {
        FileInfo GetOpenFileDialogPathName();
        FileInfo GetOpenFileDialogPathName(string filter);
    }
}