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
        public ImageSource MapBitmap { get; set; }
        public Map_View()
        {
            InitializeComponent();
            BitmapImage.Source = GenerateMap(300,300);
        }
        private void RenderAgain_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage.Source = GenerateMap(300, 300);
        }

        private ImageSource GenerateMap(int width, int height)
        {
            Random rnd = new Random();
            Bitmap worldMap = new Bitmap(width, height);
            Graphics worldGeneration = Graphics.FromImage(worldMap);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int random = rnd.Next(10);
                    if(random < 8)
                    {
                        worldGeneration.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Green), j, i, 1, 1);
                    }
                    else
                    {
                        worldGeneration.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Blue), j, i, 1, 1);
                    }
                }
            }
            worldGeneration.DrawImage(worldMap, 0, 0);
            return Imaging.CreateBitmapSourceFromHBitmap(worldMap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

    }
}
