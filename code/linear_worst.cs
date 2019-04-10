using System;
using System.Diagnostics;

namespace search
{
    class Program
    {
        public static int linearSearch(int[] array, int toSearch, int result_code)
        {
            int operationCount = 0;
            int resultCode = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == toSearch)
                {
                    operationCount++;
                    resultCode = 1;
                    return resultCode;
                }
                else
                    operationCount++;
            }

            resultCode = -1;
            return resultCode;
        }

        public static void Main(string[] args)
        {
            Random rand = new Random();
            int result = 0;
            double elapsedSeconds = 0;
            double elapsedTime = 0;

            System.Console.WriteLine("k;number;elapsed_seconds;result_code");

            for (int k = 100000000; k < (int)Math.Pow(2, 28); k += 1000000)
            {
                int[] tab = new int[k];

                for (int i = 0; i < tab.Length; i++)
                {
                    tab[i] = rand.Next(1, 1000);
                }

                int number = 1001;

                long start = Stopwatch.GetTimestamp();
                result = linearSearch(tab, number, result);
                long stop = Stopwatch.GetTimestamp();

                elapsedTime = stop - start;
                elapsedSeconds = elapsedTime * (1.0 / Stopwatch.Frequency);
                System.Console.WriteLine("{0};{1};{2:F8};{3}", k, number, elapsedSeconds, result);
            }
            Console.ReadKey();
        }
    }
}