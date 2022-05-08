using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Lab1
{
    public class Rectangle
    {
        public int X, Y, Height, Width;
        public static bool brake = false;

        public Rectangle()
        {

        }

        public Rectangle(int x, int y, int height, int width)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;

        }

        public void Save(int x, int y, int height, int width )
        {
            Rectangle abcd2 = new Rectangle(x, y, height, width);
            File.WriteAllText("Rectangle.json", JsonConvert.SerializeObject(abcd2));
        }

        public void Load()
        {
            JsonConvert.DeserializeObject<Rectangle>(File.ReadAllText("Rectangle.json"));
            
        }

        public void Moving(int l, int h, ref int x, ref int y)
        {
            x = x + l;
            y = y + h;

            Console.WriteLine("Координаты точек прямоугольника после передвижения вдоль координатной площади:");
            Console.WriteLine("Точка А(" + x + "," + y + ")");
            Console.WriteLine("Точка B(" + x + "," + (y + Width) + ")");
            Console.WriteLine("Точка C(" + (x + Height) + "," + y + ")");
            Console.WriteLine("Точка D(" + (x + Height) + "," + (y + Width) + ")");
        }

        public void Size_change(int x, int y, ref int height, ref int width)
        {
            height = height - y;
            width = width - x;

            Console.WriteLine("Координаты точек прямоугольника после изменения его размеров:");
            Console.WriteLine("Точка А(" + x + "," + y + ")");
            Console.WriteLine("Точка B(" + x + "," + (y + width) + ")");
            Console.WriteLine("Точка C(" + (x + height) + "," + y + ")");
            Console.WriteLine("Точка D(" + (x + height) + "," + (y + width) + ")");
        }

        public void Show(int x, int y, int height, int width)
        {
            Console.WriteLine("Координаты точек прямоугольника:");
            Console.WriteLine("Точка А(" + x + "," + y + ")");
            Console.WriteLine("Точка B(" + x + "," + (y + width) + ")");
            Console.WriteLine("Точка C(" + (x + height) + "," + y + ")");
            Console.WriteLine("Точка D(" + (x + height) + "," + (y + width) + ")");
        }

        public void Union_TwoRectangles(int x1, int y1, int height1, int width1, int x2, int y2, int height2, int width2)
        {
            if (x1 > x2)
            {
                int a = x1;
                x1 = x2;
                x2 = a;
            }

            if (x1 + width1 < x2 + width2)
            {
                X = x1;
                Width = x2 - x1 + width2;
            }
            else
            {
                X = x1;
                Width = width2;
            }

            if (y1 > y2)
            {
                int a = y1;
                y1 = y2;
                y2 = a;
            }

            if (y1 + height1 < y2 + height2)
            {
                Y = y1;
                Height = y2 - y1 + height2;
            }
            else
            {
                Y = y1;
                Height = height2;
            }
            Console.WriteLine("Координаты объеденяющего прямоугольника:");
            Console.WriteLine("Точка А(" + X + "," + Y + ")");
            Console.WriteLine("Точка B(" + X + "," + (Y + Width) + ")");
            Console.WriteLine("Точка C(" + (X + Height) + "," + Y + ")");
            Console.WriteLine("Точка D(" + (X + Height) + "," + (Y + Width) + ")");

        }
    }
}
