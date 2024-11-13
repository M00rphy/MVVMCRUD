using System.Windows;

namespace DataGridCRUD
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ProductViewModel();  // Set DataContext to ProductViewModel
        }
    }
}
