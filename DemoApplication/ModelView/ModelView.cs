﻿#region (c) 2024 Adam Melhem All right reserved
//   Author     : Adam Melhem
//   Email      : fm_post@hotmail.com
//   Projet     : ClearCut
//   Created    : 26.4.2024
#endregion

using ClearCut.Helpers;
using ClearCut.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClearCut.ModelView
{
    public class ModelView : IModelView
    {
        #region Public Constructors

        public ModelView(ILogger logger )
        {
            _logger = logger;
        }

        #endregion Public Constructors

        #region Command

        /// <summary>
        ///     Refresh all
        /// </summary>
        public ICommand LoadDataFile
            => new RelayCommand(async () => await LoadDataAsync());

        #endregion Command

        #region Private Fields

        private string search;
        private string maxXY;
        private string minXY;
        private string averageXY;
        private string sumXY;
        private readonly ILogger _logger;

        #endregion Private Fields

        #region Public Properties

        public ObservableCollection<TestLine> TestLines { get; set; }

        #endregion Public Properties

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        /// <summary>
        /// Fill data
        /// </summary>
        private void FillData(ICollection<TestLine> dataRecords)
        {
            search = "";
            var testLines = dataRecords.ToList();
            var trueTestLinesList = new TestLines(testLines.AsParallel().Where(o => o.Prediction).ToList());
            MaxXY = trueTestLinesList.GetMaxXY().ToString();
            AverageXY = trueTestLinesList.GetAverageXY().ToString();
            SumXY = trueTestLinesList.GetSumXY().ToString();
            MinXY = trueTestLinesList.GetMinXY().ToString();
        }

        public String MaxXY
        {
            get => "max in x,y: " + maxXY?.ToString();
            set
            {
                maxXY = value;
                OnPropertyChanged("MaxXY");
            }
        }

        public String MinXY
        {
            get => "min in x,y: " + minXY?.ToString();
            set
            {
                minXY = value;
                OnPropertyChanged("MinXY");
            }
        }

        public String AverageXY
        {
            get => "average in x,y: " + averageXY?.ToString();
            set
            {
                averageXY = value;
                OnPropertyChanged("AverageXY");
            }
        }
        public String SumXY
        {
            get => "sum in x,y: " + sumXY?.ToString();
            set
            {
                sumXY = value;
                OnPropertyChanged("SumXY");
            }
        }

        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        /// <summary>
        /// refresh data
        /// </summary>
        /// <param name="obj"></param>
        private async Task LoadDataAsync()
        {
            try
            {
                var csvFileHandler = new CSVFileHandler();
                Mouse.OverrideCursor = Cursors.Wait;
                var dataRecords = await csvFileHandler.LoadDataFromSelectedZipFileFlow();
                FillData(dataRecords);
                Mouse.OverrideCursor = Cursors.Arrow;
            } catch (Exception ex)
            {
                var msg = "Something went wrong!";
                _logger.LogError(msg, ex);
                MessageBox.Show(msg);
            }
        }

    }
}