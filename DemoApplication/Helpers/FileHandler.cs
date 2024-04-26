﻿#region (c) 2024 Adam Melhem All right reserved
//   Author     : Adam Melhem
//   Projet     : ClearCut
//   Created    : 26.4.2024
#endregion

using Microsoft.Win32;
using System.IO;

namespace ClearCut.Helpers
{
    internal abstract class FileHandler
    {
        public virtual FileInfo GetOpenFileDialogPathName()
            => this.GetOpenFileDialogPathName("*.*");

        public virtual FileInfo GetOpenFileDialogPathName(string filter)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            openFileDialog.ShowDialog();
            return new FileInfo(openFileDialog.FileName);
        }
    }
}