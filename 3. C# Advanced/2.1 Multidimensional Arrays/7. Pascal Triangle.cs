using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //array of arrays
            int[][] jaggedArray = new int[n][];

            //4 arrays
            jaggedArray[0] = new int[] { 1 };

            for (int row = 1; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new int[row + 1];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row - 1].Length > col)
                    {
                        jaggedArray[row][col] += jaggedArray[row - 1][col];
                    }
                    if (col > 0)
                    {
                        jaggedArray[row][col] += jaggedArray[row - 1][col - 1];
                    }
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
