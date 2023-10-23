using System;
using System.Collections.Generic;

namespace _3
{
    class Currency
    {
        public double ExchangeRate { get; protected set; }
        public double ConvertTo(Currency targetCurrency, double amount)
        {
            if (targetCurrency != null) return (amount / ExchangeRate) * targetCurrency.ExchangeRate;
            else throw new ArgumentException("Целевая валюта не может быть null");
        }
    }

    class Ruble : Currency
    {
        public Ruble()
        {
            ExchangeRate = 16.30;
        }
    }

    class Leu : Currency
    {
        public Leu()
        {
            ExchangeRate = 18.2;
        }
    }

    class Pound : Currency
    {
        public Pound()
        {
            ExchangeRate = 0.82;
        }
    }
    class Dollar : Currency
    {
        public Dollar()
        {
            ExchangeRate = 1;
        }
    }

    class Program
    {
        static List<string> history = new List<string>();
        static void Main()
        {
            double amount = 0;
            Ruble ruble = new Ruble();
            Leu leu = new Leu();
            Pound pound = new Pound();
            Dollar dollar = new Dollar();
            Console.Write("Введите сумму для конвертации:");
            try
            {
                amount = Convert.ToDouble(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Введите еще раз!");
                Main();

            }
            if (amount <= 0)
            {
                Console.WriteLine("Введите еще раз!");
                Main();
            }
            else
            {
                Console.WriteLine("Выберите начальную валюту \n1 - USD\n2 - Ruble PMR\n3 - Hryvnia\n4 - Leu:");
                int s = Convert.ToInt32(Console.ReadLine());
                Currency currency;
                switch (s)
                {
                    case 1:
                        currency = dollar;
                        break;
                    case 2:
                        currency = ruble;
                        break;
                    case 3:
                        currency = pound;
                        break;
                    case 4:
                        currency = leu;
                        break;
                    default:
                        Console.WriteLine("Выбор начальной валюты недействителен.");
                        return;
                }

                Console.WriteLine("Выберите целевую валюту \n1 - Ruble PMR\n2 - Hryvnia\n3 - Leu\n4 - USD:");
                int t = Convert.ToInt32(Console.ReadLine());
                Currency targetCurrency;
                switch (t)
                {
                    case 1:
                        targetCurrency = ruble;
                        break;
                    case 2:
                        targetCurrency = pound;
                        break;
                    case 3:
                        targetCurrency = leu;
                        break;
                    case 4:
                        targetCurrency = dollar;
                        break;
                    default:
                        Console.WriteLine("Выбор целевой валюты недействителен.");
                        return;
                }
                double result = currency.ConvertTo(targetCurrency, amount);
                string operation = $"{amount} {currency.GetType().Name} = {result:f2} {targetCurrency.GetType().Name}";
                history.Add(operation);
                Console.WriteLine(operation);
                if (history.Count > 3) history.RemoveAt(0);
            }
        }
    }
}