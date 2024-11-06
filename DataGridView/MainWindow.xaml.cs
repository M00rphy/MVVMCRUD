using System.Windows;


namespace DataGridView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Product Dildo = new Product();
            Dildo.SKU = "69";
            Dildo.Name = "Dildo monstruo";
            Dildo.Price = "6699";
            Dildo.Stock = "12";

            DataGridXAML.Items.Add(Dildo);
        }
        public class Product
        {
           public string SKU {  get; set; }

            public string Name { get; set; }
            public string Price {  get; set; }
            public String Stock {  get; set; }
        }
       
    }
}