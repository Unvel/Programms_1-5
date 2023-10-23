using System;
using System.Collections;
using System.Collections.Generic;

namespace _5
{
    interface IFigureCollection : IEnumerable<IFigure> { }
    abstract class FigureCollection : IFigureCollection
    {
        public List<IFigure> figures = new List<IFigure>();
        public IEnumerator<IFigure> GetEnumerator()
        {
            return figures.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    interface IFigure
    {
        double Perimeter();
        double Area();
        string SpecialProperties();
        void Info();
    }

    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            List<IFigure> figures = new List<IFigure>();
            for (int i = 0; i < 20; i++)
            {
                int r = rnd.Next(3);
                switch (r)
                {
                    case 0:
                        Rectangle p = new Rectangle(rnd.Next(1, 4), rnd.Next(1, 4));
                        figures.Add(p);
                        break;
                    case 1:
                        Ellipse e = new Ellipse(rnd.Next(1, 4), rnd.Next(1, 4));
                        figures.Add(e);
                        break;
                    case 2:
                        bool d = true;
                        while (d)
                        {
                            double a = rnd.Next(1, 4);
                            double b = rnd.Next(1, 4);
                            double c = rnd.Next(1, 4);
                            if (a + b > c && a + c > b && b + c > a)
                            {
                                Triangle f = new Triangle(a, b, c);
                                figures.Add(f);
                                d = false;
                            }
                        }
                        break;
                }
            }
            Console.WriteLine("{0,16}{1,14}{2,20}{3,17}{4,20}", "Название:", "Стороны:", "Периметр:", "Площадь:", "Особые свойства:");
            foreach (var figure in figures) figure.Info();
            Console.WriteLine();
            IEnumerator<IFigure> enumerator = figures.GetEnumerator();
            while (enumerator.MoveNext())
            {
                IFigure figure = enumerator.Current;
                figure.Info();
            }
            Console.ReadLine();
        }
    }

    public class Rectangle : IFigure
    {
        double length;
        double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public double Perimeter()
        {
            return (length + width) * 2;
        }

        public double Area()
        {
            return length * width;
        }

        public string SpecialProperties()
        {
            return length == width ? "Квадрат" : "Прямоугольник";
        }

        public void Info()
        {
            Console.WriteLine($"{SpecialProperties(),16}\t({length},{width})\t \t{Perimeter(),10}\t{Area(),10}");
        }
    }

    public class Ellipse : IFigure
    {
        double radius1;
        double radius2;

        public Ellipse(double radius1, double radius2)
        {
            this.radius1 = radius1;
            this.radius2 = radius2;
        }

        public double Perimeter()
        {
            return radius1 == radius2
                ? 2 * Math.PI * radius1
                : 4 * ((Math.PI * radius1 * radius2 + Math.Pow(radius1 - radius2, 2)) / (radius1 + radius2));
        }

        public double Area()
        {
            return Math.PI * radius1 * radius2;
        }

        public string SpecialProperties()
        {
            return radius1 == radius2 ? "Круг" : "Эллипс";
        }

        public void Info()
        {
            Console.WriteLine($"{SpecialProperties(),16}\t({radius1},{radius2})\t \t{Perimeter(),10:f2}\t{Area(),10:f2}");
        }
    }

    public class Triangle : IFigure
    {
        double side1;
        double side2;
        double side3;

        public Triangle(double side1, double side2, double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }

        public double Perimeter()
        {
            return side1 + side2 + side3;
        }

        public double Area()
        {
            double p = (side1 + side2 + side3) / 2;
            double s = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
            return s;
        }

        public string SpecialProperties()
        {
            if (side1 == side2 && side2 == side3) return "Равносторонний";

            else if (side1 == side2 || side1 == side3 || side2 == side3) return "Равнобедренный";

            else return "Разносторонний";

        }
            public void Info()
        {
            Console.WriteLine($"{"Треугольник",16}\t({side1},{side2},{side3})\t \t{Perimeter(),10:f2}\t{Area(),10:f2}\t{SpecialProperties()}");
        }
    }
}