using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Didyoudoit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Load.init();
            MainDataGrid.DataContext = Data.Klasses[0].getTable().DefaultView;
            KlassListBox.ItemsSource = Data.Klasses;
        }

        private void KlassListClicked(object sender, RoutedEventArgs e)
        {
            Utils.Log(((TextBlock)sender).Text);
            MainDataGrid.DataContext = Data.KlassDicitonary[((TextBlock)sender).Text].getTable().DefaultView;
        }
    }
}
