using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal class MagicSquare
    {
        // like the depth -> main check -> to be valid magic square
        static bool IsMagicSquare(int[,] square)
        {
            int n = square.GetLength(0);
            int sum = 0;

            // Calculate the sum of the first row
            for (int j = 0; j < n; j++)
            {
                sum += square[0, j];
            }

            // Check rows
            for (int i = 1; i < n; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < n; j++)
                {
                    rowSum += square[i, j];
                }
                if (rowSum != sum)
                {
                    return false;
                }
            }

            // Check columns
            for (int j = 0; j < n; j++)
            {
                int colSum = 0;
                for (int i = 0; i < n; i++)
                {
                    colSum += square[i, j];
                }
                if (colSum != sum)
                {
                    return false;
                }
            }

            // Check diagonals
            int diagSum1 = 0;
            int diagSum2 = 0;
            for (int i = 0; i < n; i++)
            {
                diagSum1 += square[i, i];
                diagSum2 += square[i, n - 1 - i];
            }

            return diagSum1 == sum && diagSum2 == sum;
        }

        // printing
        static void PrintMagicSquare(int[,] square)
        {
            int n = square.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(square[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void Caller()
        {
            GenerateMagicSquares();
        }

        public static int formingMagicSquare(List<List<int>> s)
        {
            List<int[,]> magicSquares = GenerateMagicSquares();

            int minCost = 1000000;

            int cost;
            for (int i = 0; i < magicSquares.Count; i++)
            {
                int n = magicSquares[i].GetLength(0);
                int m = magicSquares[i].GetLength(1);

                cost = 0;

                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        if (s[j][k] != magicSquares[i][j,k])
                        {
                            cost += Math.Abs(s[j][k] - magicSquares[i][j, k]);
                        }
                    }
                }

                if (cost < minCost)
                {
                    minCost = cost;
                }
            }

            return minCost;
        }

        public static List<int[,]> GenerateMagicSquares()
        {
            List<int[,]> squares = new List<int[,]>();

            int n = 3;
            int[] permutation = new int[n * n];
            for (int i = 0; i < n * n; i++)
            {
                permutation[i] = i + 1;
            }

            do
            {
                int[,] magicSquare = new int[n, n];

                // Forming the square
                int index = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        magicSquare[i, j] = permutation[index++];
                    }
                }

                // Checking if it's a magic square
                bool isMagic = IsMagicSquare(magicSquare);

                // If it's magic, print it
                if (isMagic)
                {
                    PrintMagicSquare(magicSquare);
                    squares.Add(magicSquare);
                }
            } while (NextPermutation(permutation));

            return squares;
        }

        static bool NextPermutation(int[] array)
        {
            // why minus 2
            int i = array.Length - 2; // 7
            while (i >= 0 && array[i] >= array[i + 1])
            {
                i--;
            }

            if (i < 0)
            {
                return false;
            }

            int j = array.Length - 1;
            while (array[j] <= array[i])
            {
                j--;
            }

            Swap(array, i, j);

            Array.Reverse(array, i + 1, array.Length - i - 1);

            return true;
        }

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
