using ClearCut.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ClearCut.ModelView
{
    public interface IModelView: INotifyPropertyChanged
    {
        string AverageXY { get; set; }
        ICommand LoadDataFile { get; }
        string MaxXY { get; set; }
        string MinXY { get; set; }
        string SumXY { get; set; }
        ObservableCollection<TestLine> TestLines { get; set; }

    }
}