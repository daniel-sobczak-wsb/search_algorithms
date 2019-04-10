using System;
using System.Diagnostics;

namespace search
{
    class Program
    {
        public static (int result, int opernum) linearSearch(int[] array, int toSearch)
        {
            int operationCount = 0;
            int resultCode = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == toSearch)
                {
                    operationCount++;
                    resultCode = 1;
                    return (result: resultCode, opernum: operationCount);
                }
                else
                    operationCount++;
            }

            resultCode = -1;
            return (result: resultCode, opernum: operationCount);
        }

        public static void Main(string[] args)
        {
            Random rand = new Random();
            double elapsedSeconds = 0;
            double elapsedTime = 0;

            System.Console.WriteLine("k;number;elapsed_seconds;result_code;oper_number");

            for (int k = 100000000; k < (int)Math.Pow(2, 28); k += 1000000)
            {
                int[] tab = new int[k];

                for (int i = 0; i < tab.Length; i++)
                {
                    tab[i] = rand.Next(1, 1000);
                }

                int number = tab[(0 + (tab.Length - 1) / 2)];

                long start = Stopwatch.GetTimestamp();
                (int result, int opernum) = linearSearch(tab, number);
                long stop = Stopwatch.GetTimestamp();

                elapsedTime = stop - start;
                elapsedSeconds = elapsedTime * (1.0 / Stopwatch.Frequency);
                System.Console.WriteLine("{0};{1};{2:F8};{3};{4}", k, number, elapsedSeconds, result, opernum);
            }
            Console.ReadKey();
        }
    }
}