#region (c) 2024 Adam Melhem All right reserved
//   Author     : Adam Melhem
//   Email.     : fm_post@hotmail.com
//   Projet     : ClearCut
//   Created    : 26.4.2024
#endregion

using Microsoft.Win32;
using System.IO;

namespace ClearCut.Helpers
{
    public abstract class FileHandler : IFileHandler
    {
        public virtual FileInfo GetOpenFileDialogPathName()
            => this.GetOpenFileDialogPathName("*.*");

        public virtual FileInfo GetOpenFileDialogPathName(string filter)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            openFileDialog.ShowDialog();
            if (File.Exists(openFileDialog.FileName))
            {
                return new FileInfo(openFileDialog.FileName);
            }
            else
            { return null; }
        }
    }
}
