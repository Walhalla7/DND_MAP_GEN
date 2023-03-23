using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DND_Map_Gen_v._0._1
{
    /// <summary>
    /// Interaction logic for Map_View.xaml
    /// </summary>
    public partial class Map_View : Page
    {
        BackgroundMapGeneration backgroundMapGeneration = new BackgroundMapGeneration(300,300);
        public ImageSource MapBitmap { get; set; }
        public Map_View()
        {
            InitializeComponent();
            BitmapImage.Source = backgroundMapGeneration.GenerateMap();
        }
        private void RenderAgain_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage.Source = backgroundMapGeneration.GenerateMap();
        }
        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Visibility = Visibility.Visible;
            Window win = (Window)this.Parent;
            win.Close();
        }

    }
}
