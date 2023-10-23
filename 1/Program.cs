using System;

namespace _1
{
    abstract class GeometricFigure
    {
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public abstract void CalculateArea();
        public abstract void CalculatePerimeter();
        public abstract void PrintInfo();
    }
    class Triangle : GeometricFigure
    {
        private double A;
        private double B;
        private double C;
        public Triangle(double side_A, double side_B, double side_C)
        {
            this.A = side_A;
            this.B = side_B;
            this.C = side_C;
            CalculateArea();
            CalculatePerimeter();
        }
        public override void CalculateArea()
        {
            double s = (A + B + C) / 2;
            Area = Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
        public override void CalculatePerimeter()
        {
            Perimeter = A + B + C;
        }
        public override void PrintInfo()
        {
            Console.Write($"Треугольник ({A}, {B}, {C})");
            Console.Write($"\tПлощадь: {Area:#.##}\tПериметр: {Perimeter:#.##}");
            Console.Write($"\tТип фигуры: ");
            if (A == B && B == C) Console.Write("Равносторонний");
            else if (A == B || A == C || B == C) Console.Write("Равнобедренный");
            else Console.Write("Разносторонний");
            Console.WriteLine($"\tПрямоугольный: {Right_Triangle()}");
        }
        private bool Right_Triangle()
        {
            return (A * A + B * B == C * C) || (A * A + C * C == B * B) || (B * B + C * C == A * A);
        }
    }
    class Rectangle : GeometricFigure
    {
        private double length;
        private double width;
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
            CalculateArea();
            CalculatePerimeter();
        }
        public override void CalculateArea()
        {
            Area = length * width;
        }
        public override void CalculatePerimeter()
        {
            Perimeter = 2 * (length + width);
        }
        public override void PrintInfo()
        {
            Console.Write($"Прямоугольник ({length}, {width})");
            Console.Write($"\tПлощадь: {Area:#.##}\tПериметр: {Perimeter:#.##}");
            if (length == width) Console.WriteLine("\tТип фигуры: Квадрат");
            else Console.WriteLine("\tТип фигуры: Прямоугольник");
        }
    }
    class Oval : GeometricFigure
    {
        private double major_radius;
        private double minor_radius;
        public Oval(double major_radius, double minor_radius)
        {
            this.major_radius = major_radius;
            this.minor_radius = minor_radius;
            CalculateArea();
            CalculatePerimeter();
        }
        public override void CalculateArea()
        {
            Area = Math.PI * major_radius * minor_radius;
        }
        public override void CalculatePerimeter()
        {
            Perimeter = 2 * Math.PI * Math.Sqrt((major_radius * major_radius + minor_radius * minor_radius) / 2);
        }
        public override void PrintInfo()
        {
            Console.Write($"Овал ({minor_radius},{major_radius})");
            Console.Write($"\t\t\tПлощадь: {Area:#.##}\tПериметр: {Perimeter:#.##}");
            if (major_radius == minor_radius) Console.WriteLine("\tТип фигуры: Круг");
            else Console.WriteLine("\tТип фигуры: Эллипс");
        }
    }
    internal class Program
    {
        static void Main()
        {
            Random rand = new Random();
            for (int i = 1; i <= 10; i++)
            {
                GeometricFigure selected_figure;
                Console.Write($"№{i}: ");
                int index = rand.Next(0, 3);
                if (index == 0)
                {
                    double a, b, c;
                    do
                    {
                        a = rand.Next(1, 6);
                        b = rand.Next(1, 6);
                        c = rand.Next(1, 6);
                    } while (!(a + b > c && a + c > b && b + c > a));
                    selected_figure = new Triangle(a, b, c);

                }
                else if (index == 1)
                {
                    selected_figure = new Rectangle(rand.Next(1, 6), rand.Next(1, 6));

                }
                else
                {
                    selected_figure = new Oval(rand.Next(1, 6), rand.Next(1, 6));
                }
                selected_figure.PrintInfo();
            }
            Console.ReadLine();
        }
    }
}
