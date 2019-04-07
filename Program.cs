using System;

namespace search
{
    class Program
    {
        public static void binarySearch(int l, int r, int[] array, int m, int toSearch)
        {
            do
            {
                m = (l+r) / 2;
                if (array[m] == toSearch)
                {
                    System.Console.WriteLine("Element {0} znaleziony w indeksie {1}", toSearch, m);
                    break;
                }
                else if (array[m] != toSearch)
                    if (array[m] > toSearch)
                        r = m - 1;
                    else
                        l = m + 1;
            } while (!(l > r));
            if (l > r)
                System.Console.WriteLine("Nie znaleziono podanego elementu");
        }
        
        public static void Main(string[] args)
        {
            int[] table = {1, 2, 5, 8, 9, 11, 15, 20};

            int left = 0;
            int right = table.Length - 1;
            int middle = (left + right) / 2;

            System.Console.WriteLine("Podaj liczbę do wyszukania");
            int number = int.Parse(Console.ReadLine());

            /* if (table[middle] == number)
                System.Console.WriteLine("Liczba jest w środku tablicy");
            else */
            binarySearch(left, right, table, middle, number) ;           

            //System.Console.WriteLine(middle);
            Console.ReadKey();
        }
    }
}
