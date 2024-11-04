using MVVMCRUD;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Trace.WriteLine("Later fucker");
        MVVMCRUD.MainPage window = new MainPage();
        UserViewModel VM = new UserViewModel();
        window.DataContext = VM;
        window.Show();
    }
}