using System;
using System.Transactions;

namespace Task_3
{
    class Converter
    {
        public Converter(double dollarCost, double euroCost)
        {
            USDCost = dollarCost;
            EURCost = euroCost;
        }
        public double USDToUAH(double USD)
        {
            return USD * USDCost;
        }
        public double UAHToUSD(double UAH)
        {
            return UAH / USDCost;
        }
        public double EURToUAH(double EUR)
        {
            return EUR * EURCost;
        }
        public double UAHToEUR(double UAH)
        {
            return UAH / EURCost;
        }

        private readonly double USDCost;
        private readonly double EURCost;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double dollarPrice = Convert.ToDouble(Console.ReadLine());
            double euroPrice = Convert.ToDouble(Console.ReadLine());

            Converter converter = new Converter(dollarPrice, euroPrice);

            string typeFrom = Console.ReadLine();

            while(typeFrom != "UAH" && typeFrom != "USD" && typeFrom != "EUR")
            {
                Console.WriteLine("Wrong type of currency");
                typeFrom = Console.ReadLine();
            }

            double amount = Convert.ToDouble(Console.ReadLine());

            string typeTo = Console.ReadLine();

            if (typeTo != "UAH" && typeTo != "USD" && typeTo != "EUR")
            {
                Console.WriteLine("Wrong type of currency");
                typeFrom = Console.ReadLine();
            }
            if(typeTo == typeFrom)
            {
                Console.WriteLine(amount);
            }
            if (typeFrom == "UAH" && typeTo == "USD")
            {
                Console.WriteLine(converter.UAHToUSD(amount)); 
            }
            if (typeFrom == "UAH" && typeTo == "EUR")
            {
                Console.WriteLine(converter.UAHToEUR(amount));
            }
            if(typeFrom == "USD" && typeTo == "UAH")
            {
                Console.WriteLine(converter.USDToUAH(amount));
            }
            if(typeFrom == "EUR" && typeTo == "UAH")
            {
                Console.WriteLine(converter.EURToUAH(amount));
            }
            Console.ReadKey();
        }
    }
}
