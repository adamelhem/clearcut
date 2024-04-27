using Ninject;
using System.Windows;

namespace ClearCut
{
    /// <summary>
    ///     Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            var kernel = new StandardKernel();
            var appVM = kernel.Get<ModelView.ModelView>();
            kernel.Bind<ModelView.IModelView>().To<ModelView.ModelView>();
            MainWindow = kernel.Get<MainWindow>();
            MainWindow.DataContext = appVM;
            MainWindow.Show();
        }
    }
}
