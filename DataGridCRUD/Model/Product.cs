using System.ComponentModel;

public class Product : INotifyPropertyChanged
{
    private string sku;
    private string name;
    private string price;
    private string stock;

    public string SKU
    {
        get => sku;
        set { sku = value; OnPropertyChanged(nameof(SKU)); }
    }

    public string Name
    {
        get => name;
        set { name = value; OnPropertyChanged(nameof(Name)); }
    }

    public string Price
    {
        get => price;
        set { price = value; OnPropertyChanged(nameof(Price)); }
    }

    public string Stock
    {
        get => stock;
        set { stock = value; OnPropertyChanged(nameof(Stock)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}


