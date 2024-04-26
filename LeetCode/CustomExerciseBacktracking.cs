using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal class Backtracking
    {
        static int N;
        public static void Mine()
        {
            N = int.Parse(Console.ReadLine());
            int[,] board = new int[N, N];

            if (!TheBoardSolver(board, 0))
            {
                Console.WriteLine("Solution not found.");
            }
            PrintBoard(board);
            Console.ReadLine();
        }

        public static bool TheBoardSolver(int[,] board, int col)  
        {
            if (col >= N)
            {
                return true;
            }

            // for every row (move the row)
            for (int i = 0; i < N; i++)
            {
                if (IsValid(board, i, col))
                {
                    board[i, col] = 1;
                    if (TheBoardSolver(board, col + 1))
                    {
                        return true;
                    }

                    board[i, col] = 0;
                }
            }

            return false;
        }

        public static bool IsValid(int[,] board, int row, int col)
        {
            // horizontally
            for (int i = col; i >= 0; i--)
            {
                if (board[row, i] == 1)
                {
                    return false;
                }
            }

            // diagonal 1
            for (int i = col, j = row; i >= 0 && j >= 0; i--, j--)
            {
                if (board[j, i] == 1)
                {
                    return false;
                }
            }
            // diagonal 2
            for (int i = col, j = row; i < N && j >= 0; i++, j--)
            {
                if (board[j, i] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        static void PrintBoard(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.Write("\n");
            }
        }
    }
}
