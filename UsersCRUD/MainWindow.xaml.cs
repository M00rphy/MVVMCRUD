﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UsersCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (uEmail.Text == "admin@mail.com" && uPass.Text == "admin")
            {
                UserControlWindow UserC = new UserControlWindow();
                this.Hide();
                UserC.Show();
            }
            else
            {
                MessageBox.Show("Couldn't find user!");
            }
        }
    }
}