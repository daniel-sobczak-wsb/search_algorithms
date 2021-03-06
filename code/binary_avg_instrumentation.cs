﻿using System;
using System.Diagnostics;

namespace search
{
    class Program
    {
        public static (int result, int opernum) binarySearch(int l, int r, int[] array, int m, int toSearch)
        {
            int operationCount = 0;
            int resultCode = 0;

            do
            {
                m = (l+r) / 2;
                if (array[m] == toSearch)
                {
                    operationCount++;
                    resultCode = 1;
                    break;
                }
                else if (array[m] != toSearch)
                    if (array[m] > toSearch) {
                        r = m - 1;
                        operationCount++;
                    }
                    else {
                        l = m + 1;
                        operationCount++;
                    }
            } while (!(l > r));
            if (l > r)
            {
                System.Console.WriteLine("Nie znaleziono podanego elementu");
                resultCode = -1;
            }
           
           return (result: resultCode, opernum: operationCount);
        }
       
        public static void Main(string[] args)
        {
            Random rand = new Random();
            int count = 1;  
            double elapsedSeconds = 0;
            double elapsedTime = 0;

            System.Console.WriteLine("k;number;elapsed_seconds;result_code;oper_number"); 

            for (int k = 2000000; k < (int) Math.Pow(2, 28); k += 100000)
            {
                int[] tab = new int[k];
                
                for (int i = 0; i < tab.Length; i++)
                {
                    tab[i] = i+1;
                }
                count++;

                int number = rand.Next(1, tab.Length);
                int left = 0;
                int right = tab.Length - 1;
                int middle = (left + right) / 2;
 
                long start = Stopwatch.GetTimestamp();
                (int result, int opernum) = binarySearch(left, right, tab, middle, number) ;
                long stop = Stopwatch.GetTimestamp();
 
                elapsedTime = stop - start;
                elapsedSeconds = elapsedTime * (1.0 / Stopwatch.Frequency);
                System.Console.WriteLine("{0};{1};{2:F8};{3};{4}", k, number, elapsedSeconds, result, opernum);
            }
            Console.ReadKey();
        }
    }
}