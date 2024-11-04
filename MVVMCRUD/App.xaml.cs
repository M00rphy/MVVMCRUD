using MVVMCRUD;
using System.Configuration;
using System.Data;
using System.Windows;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        WpfMVVMSample.MainWindow window = new MainWindow();
        UserViewModel VM = new UserViewModel();
        window.DataContext = VM;
        window.Show();
    }
}