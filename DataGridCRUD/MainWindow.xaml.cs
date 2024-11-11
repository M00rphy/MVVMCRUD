using System.Windows;


namespace DataGridCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<Product> ProductsList;

        public MainWindow()
        {
            InitializeComponent();
            //Product Dildo = new Product();
            //Dildo.SKU = "69";
            //Dildo.Name = "Dildo monstruo";
            //Dildo.Price = "6699";
            //Dildo.Stock = "12";

            ProductsList = new List<Product>
        {
            new Product { SKU = "1", Name = "Dildo Monstruo", Price = "666", Stock = "Delhi"},
            new Product { SKU = "1", Name = "Dildo Monstruo", Price = "666", Stock = "Delhi"},
            new Product { SKU = "1", Name = "Dildo Monstruo", Price = "666", Stock = "Delhi"},


        };
            foreach (var item in ProductsList)
            {
                DataGrid2.Items.Add(item);
            }
            //DataGridXAML.Items.Add(ProductsList);


        }
        public class Product
        {
           public string SKU {  get; set; }

            public string Name { get; set; }
            public string Price {  get; set; }
            public String Stock {  get; set; }
        }

        private void NewProd_Click(object sender, RoutedEventArgs e)
        {
            Product tempProduct = new Product();
            tempProduct.SKU = SKUTB.Text;
            tempProduct.Name = NameTB.Text;
            tempProduct.Price = PriceTB.Text;
            tempProduct.Stock = StockTB.Text;

            DataGridXAML2.Items.Add(tempProduct);
        }
    }
}