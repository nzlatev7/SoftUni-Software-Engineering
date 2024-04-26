using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestApp
{
    public class WordSearch
    {
        public static bool Exist(char[][] board, string word)
        {
            int m = board.Length; // 3
            int n = board[0].Length; // 4

            Func<int, int, int, bool> backtrack = null;
            // indeces of the potion, of the word
            backtrack = (i, j, k) => {
                // the bottom of our recursion
                if (k == word.Length)
                {
                    return true;
                }
                // is in the valid field
                if (i < 0 || i >= m || j < 0 || j >= n || board[i][j] != word[k])
                {
                    return false;
                }

                char temp = board[i][j];

                // reset the value -> to not be possible to not go there again
                board[i][j] = '\0';
                bool result = backtrack(i + 1, j, k + 1) ||
                              backtrack(i - 1, j, k + 1) ||
                              backtrack(i, j + 1, k + 1) ||
                              backtrack(i, j - 1, k + 1);

                board[i][j] = temp;
                return result;
            };

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (backtrack(i, j, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
