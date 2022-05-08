using System;

namespace Lab1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using Newtonsoft.Json;

    namespace Laba1
    {
        internal class Program
        {
            
            static void Main(string[] args)
            {
                Console.WriteLine("Добро пожаловать");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Загрузить последний сохраненный прямоугольник");
                Console.WriteLine("2 - Создать новый");

                int status1 = 1;
                
                while (status1 != 0)
                {
                    int a = int.Parse(Console.ReadLine());
                    switch (a)
                    {
                        case 1:
                            var abcd3 = JsonConvert.DeserializeObject<Rectangle>(File.ReadAllText("Rectangle.json"));
                            
                            Console.WriteLine("Координаты точек прямоугольника:");
                            Console.WriteLine("Точка А(" + abcd3.X + "," + abcd3.Y + ")");
                            Console.WriteLine("Точка B(" + abcd3.X + "," + (abcd3.Y + abcd3.Width) + ")");
                            Console.WriteLine("Точка C(" + (abcd3.X + abcd3.Height) + "," + abcd3.Y + ")");
                            Console.WriteLine("Точка D(" + (abcd3.X + abcd3.Height) + "," + (abcd3.Y + abcd3.Width) + ")");
                            Console.WriteLine();
                            Console.WriteLine("Выберите действие:");
                            Console.WriteLine("1 - Загрузить последний сохраненный прямоугольник");
                            Console.WriteLine("2 - Создать новый");

                            break;
                        case 2: status1 = 0; break;
                        default: Console.WriteLine("Введите корректное значение"); break;
                    }
                }

                
                 
                Console.WriteLine("Для построения прямоугольника введите три параметра: левая нижняя точка, ширина и высота");
                Console.Write("Введите значение координаты Х: ");
                int x = int.Parse(Console.ReadLine()); Console.WriteLine();
                Console.Write("Введите значение координаты У: ");
                int y = int.Parse(Console.ReadLine()); Console.WriteLine();
                Console.Write("Введите значение высоты: ");
                int height = int.Parse(Console.ReadLine()); Console.WriteLine();
                Console.Write("Введите значение ширины: ");
                int width = int.Parse(Console.ReadLine()); Console.WriteLine();

                Rectangle abcd = new Rectangle(x, y, height, width);
                    

                Console.WriteLine("Координаты прямоугольника ABCD: ");
                abcd.Show(x, y, height, width);

                Console.WriteLine("Перед вами список с операциями номерами , относительно прямоугольника ABCD:");
                Console.WriteLine("1 - Передвижение по координатной плоскости ");
                Console.WriteLine("2 - Изменение размеров прямоугольника");
                Console.WriteLine("3 - Построение прямоугольника,что объеденяет два заданных:");
                Console.WriteLine("4 - Сохранить прямоугольник");
                Console.WriteLine("5 - Выход");

                Console.Write("Введите номер действия: ");
                
                Console.WriteLine();

                int status2 = 1;
                while (status2 != 0)
                {
                    int b = int.Parse(Console.ReadLine());
                    switch (b)
                    {
                        case 1:
                            Console.Write("На сколько единиц хотите поднять/опустить значение параметра Х: ");
                            int l = int.Parse(Console.ReadLine());
                            Console.Write("На сколько единиц хотите поднять/опустить значение параметра Y: ");
                            int h = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            abcd.Moving(l, h, ref x, ref y);
                            Console.WriteLine();
                            Console.WriteLine("Перед вами список с операциями номерами , относительно прямоугольника ABCD:");
                            Console.WriteLine("1 - Передвижение по координатной плоскости ");
                            Console.WriteLine("2 - Изменение размеров прямоугольника");
                            Console.WriteLine("3 - Построение прямоугольника,что объеденяет два заданных:");
                            Console.WriteLine("4 - Сохранить прямоугольник");
                            Console.WriteLine("5 - Выход");

                            break;
                        case 2:
                            Console.Write("На сколько единиц хотите изменить значение параметра ширины: ");
                            int dx = int.Parse(Console.ReadLine());
                            Console.Write("На сколько единиц хотите изменить значение параметра высоты: ");
                            int dy = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            abcd.Size_change(dx, dy, ref height, ref width);
                            Console.WriteLine();
                            Console.WriteLine("Перед вами список с операциями номерами , относительно прямоугольника ABCD:");
                            Console.WriteLine("1 - Передвижение по координатной плоскости ");
                            Console.WriteLine("2 - Изменение размеров прямоугольника");
                            Console.WriteLine("3 - Построение прямоугольника,что объеденяет два заданных:");
                            Console.WriteLine("4 - Сохранить прямоугольник");
                            Console.WriteLine("5 - Выход");
                            break;
                        case 3:
                            Console.WriteLine("Для условия надо создать второй прямоугольник: введите параметры нижней левой точки, высоты и ширины");
                            Console.Write("Введите значение координаты Х: ");
                            int x2 = int.Parse(Console.ReadLine()); Console.WriteLine();
                            Console.Write("Введите значение координаты У: ");
                            int y2 = int.Parse(Console.ReadLine()); Console.WriteLine();
                            Console.Write("Введите значение высоты: "); Console.WriteLine();
                            int height2 = int.Parse(Console.ReadLine());
                            Console.Write("Введите значение ширины: "); Console.WriteLine();
                            int width2 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Координаты прямоугольника А1B1C1D1:");
                            abcd.Show(x2, y2, height2, width2);
                            abcd.Union_TwoRectangles(x, y, height, width, x2, y2, height2, width2);
                            Console.WriteLine();
                            Console.WriteLine("Перед вами список с операциями номерами , относительно прямоугольника ABCD:");
                            Console.WriteLine("1 - Передвижение по координатной плоскости ");
                            Console.WriteLine("2 - Изменение размеров прямоугольника");
                            Console.WriteLine("3 - Построение прямоугольника,что объеденяет два заданных:");
                            Console.WriteLine("4 - Сохранить прямоугольник");
                            Console.WriteLine("5 - Выход");
                            break;
                        case 4:
                            abcd.Save(x,y,height,width);
                            Console.WriteLine("Вы сохранили прямоугольник");
                            Console.WriteLine();
                            Console.WriteLine("Перед вами список с операциями номерами , относительно прямоугольника ABCD:");
                            Console.WriteLine("1 - Передвижение по координатной плоскости ");
                            Console.WriteLine("2 - Изменение размеров прямоугольника");
                            Console.WriteLine("3 - Построение прямоугольника,что объеденяет два заданных:");
                            Console.WriteLine("4 - Сохранить прямоугольник");
                            Console.WriteLine("5 - Выход");
                            break;
                        case 5:
                            Console.WriteLine("До свидания"); status2 = 0;
                            break;
                        default: Console.WriteLine("Введите корректное значение"); break;
                    }
                    
                }




            }
        }
    }
}
