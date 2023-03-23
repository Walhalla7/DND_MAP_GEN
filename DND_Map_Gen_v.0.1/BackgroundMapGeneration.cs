using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace DND_Map_Gen_v._0._1
{
    internal class BackgroundMapGeneration
    {
        char[,] worldMapLayout;

        public BackgroundMapGeneration(int height, int width)
        {
            worldMapLayout = new char[height, width];
        }

        public char[,] getMapLayout()
        {
            return worldMapLayout;
        }

        private void populateMap()
        {
            Random rnd = new Random();
            int mapHeight = worldMapLayout.GetLength(0);
            int mapWidth = worldMapLayout.GetLength(1);
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    int random = rnd.Next(10);
                    if (i < (1/5 * mapHeight) || i > (4 / 5 * mapHeight) || j < (1 / 5 * mapWidth) || j > (4 / 5 * mapWidth))
                    {
                        if (random < 1)
                        {
                            worldMapLayout[i, j] = 'g';
                        }
                        else
                        {
                            worldMapLayout[i, j] = 'b';
                        }
                    }
                    else
                    {
                        if (random < 9)
                        {
                            worldMapLayout[i, j] = 'g';
                        }
                        else
                        {
                            worldMapLayout[i, j] = 'b';
                        }
                    }
                    
                    
                }
            }
        }

        public ImageSource GenerateMap()
        {
            
            Bitmap worldMap = new Bitmap(worldMapLayout.GetLength(1), worldMapLayout.GetLength(0));
            Graphics worldGeneration = Graphics.FromImage(worldMap);
            populateMap();

            for (int i = 0; i < worldMapLayout.GetLength(0); i++)
            {
                for (int j = 0; j < worldMapLayout.GetLength(1); j++)
                {
                    if (worldMapLayout[i,j] == 'g')
                    {
                        worldGeneration.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Green), i,j, 1, 1);
                    }
                    else
                    {
                        worldGeneration.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Blue), i,j, 1, 1);
                    }
                }
            }
            worldGeneration.DrawImage(worldMap, 0, 0);
            return Imaging.CreateBitmapSourceFromHBitmap(worldMap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
