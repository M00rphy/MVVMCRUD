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

        private void NewProd_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product
            {
                SKU = SKUTB.Text,
                Name = NameTB.Text,
                Price = PriceTB.Text,
                Stock = StockTB.Text
            };

            // Access the ViewModel and add the new product to the collection
            var viewModel = DataContext as ProductViewModel;
            viewModel?.Products.Add(newProduct);
        }
    }
}
