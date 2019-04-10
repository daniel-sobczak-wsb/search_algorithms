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
                if (array[i] == toSearch) {
                    operationCount++;
                    resultCode = 1;
                    return resultCode;
                }
                else
                    operationCount++;
            }
           
            //System.Console.WriteLine("Liczba operacji: {0}", operationCount);
            resultCode = -1;
           //return operationCount;
           return resultCode;
        }
       
        public static void Main(string[] args)
        {
            Random rand = new Random();
            //int count = 1; 
            int result = 0; 
            double elapsedSeconds = 0;
            double elapsedTime = 0;

            System.Console.WriteLine("k;number;elapsed_seconds;result_code"); 
                    
            for (int k = 100000000; k < (int) Math.Pow(2, 28); k += 1000000)
            {
                int[] tab = new int[k];
                
                for (int i = 0; i < tab.Length; i++)
                {
                    tab[i] = rand.Next(1, 1000);
                }
                //System.Console.WriteLine("Utworzona tablicę nr {0}", count);
                //count++;

                int number = tab[(0 + (tab.Length - 1) / 2)];
                /* int left = 0;
                int right = tab.Length - 1;
                int middle = (left + right) / 2; */
 
                long start = Stopwatch.GetTimestamp();
                result = linearSearch(tab, number, result) ;
                long stop = Stopwatch.GetTimestamp();
 
                elapsedTime = stop - start;
                elapsedSeconds = elapsedTime * (1.0 / Stopwatch.Frequency);
                System.Console.WriteLine("{0};{1};{2:F8};{3}", k, number, elapsedSeconds, result);
            }
            Console.ReadKey();
 
            /* int[] table = {1, 2, 5, 8, 9, 11, 15, 20};
 
            int left = 0;
            int right = table.Length - 1;
            int middle = (left + right) / 2;
 
            System.Console.WriteLine("Podaj liczbę do wyszukania");
            int number = int.Parse(Console.ReadLine());
 
            binarySearch(left, right, table, middle, number) ;          
 
            Console.ReadKey(); */
        }
    }
}