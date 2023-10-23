using System;
using System.Diagnostics;

namespace _4
{
    class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            int a = 3432;
            stopwatch.Start();
            object o = a;
            stopwatch.Stop();
            long time = stopwatch.ElapsedTicks;
            string packagingTime = String.Format("{0} тиков", time);
            Console.WriteLine("Время упаковки: " + packagingTime);
            stopwatch.Reset();
            stopwatch.Start();
            int b = (int)o;
            stopwatch.Stop();
            time = stopwatch.ElapsedTicks;
            string unpackagingTime = String.Format("{0} тиков", time);
            Console.WriteLine("\nВремя распаковки: " + unpackagingTime);
            Console.ReadLine();
        }
    }
}
