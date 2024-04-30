using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal class ClimbingTheLeaderboard
    {
        // mine solution
        public static List<int> ClimbingLeaderboard(List<int> ranked, List<int> player)
        {
            List<int> ranking = new List<int>();
            for (int i = 0; i < player.Count; i++)
            {
                int rankFromGame = GiveRankFromGame(ranked, player[i]);
                ranking.Add(rankFromGame);
            }

            return ranking;
        }

        static int GiveRankFromGame(List<int> ranked, int curr)
        {
            ranked.Add(curr);
            ranked.Sort((a, b) => b.CompareTo(a));

            int currRank = 1;
            Hashtable hashtable = new Hashtable();

            for (int i = 0; i < ranked.Count; i++)
            {
                if (hashtable.ContainsKey(ranked[i]))
                {
                    continue;
                }

                hashtable.Add(ranked[i], currRank);
                currRank++;
            }

            int rank = int.Parse(hashtable[curr].ToString());
            return rank;
        }


        /////////////////////
        /// Stackoverflow ///
        /////////////////////

        public static List<int> ClimbingLeaderboard2(List<int> scores, List<int> alice)
        {
            // 100,90,90,80 - ranked
            // 70,80,105 - alice
            // two pointers -> one alice at the start array -> i - start, j - from end of ranked

            int j = 1, i = 1;
            // this is to remove duplicates from the scores vector
            //for (i = 1; i < scores.Count; i++)
            //{
            //    // 90 != 100
            //    if (scores[i] != scores[i - 1])
            //    {
            //        scores[j++] = scores[i];
            //    }
            //}

            //int size = scores.Count;
            //for (i = 0; i < size - j; i++)
            //{
            //    scores.RemoveAt(scores.Count - 1);
            //}
            scores = scores.Distinct().ToList();

            // 100, 90, 80
            // 70, 80, 105

            List<int> ranks = new List<int>();

            i = 0; // start of alice array
            j = scores.Count() - 1; // end of scores

            // loop over the alice indeces
            while (i < alice.Count())
            {
                if (j < 0)
                {
                    ranks.Add(1);
                    i++;
                    continue;
                }

                // 70 < 80
                if (alice[i] < scores[j])
                {
                    // j + 2 -> 4
                    ranks.Add(j + 2);

                    // move to the next element
                    i++;
                }
                else if (alice[i] > scores[j])
                {
                    j--;
                }
                else
                {
                    ranks.Add(j + 1);
                    i++;
                }
            }

            return ranks;
        }

        public static List<int> ClimbingLeaderboard3(List<int> ranked, List<int> player)
        {
            // 100, 90, 80
            // 70, 80, 105

            List<int> result = new List<int>();
            ranked = ranked.Distinct().ToList();
            var pLength = player.Count;
            var rLength = ranked.Count - 1;

            int j = rLength;
            for (int i = 0; i < pLength; i++)
            {
                for (; j >= 0; j--)
                {
                    if (player[i] == ranked[j])
                    {
                        result.Add(j + 1);
                        break;
                    }
                    else if (player[i] < ranked[j])
                    {
                        result.Add(j + 2);
                        break;
                    }
                    else if (player[i] > ranked[j] && j == 0)
                    {
                        result.Add(1);
                        break;
                    }
                }
            }

            return result;
        }


        // video explaination

        public static List<int> ClimbingLeaderboard4(List<int> ranked, List<int> player)
        {
            List<int> result = new List<int>();

            var cleanerRank = ranked.ToHashSet().ToArray();
            int i = cleanerRank.Length - 1; // max rank

            for (int j = 0; j < player.Count; j++)
            {
                bool rankFound = false;

                while (!rankFound && i >= 0)
                {
                    if (player[j] < cleanerRank[i])
                    {
                        result.Add(i + 2);
                        rankFound = true;
                    }
                    else if (player[j] == cleanerRank[i])
                    {
                        result.Add(i + 1);
                        rankFound = true;
                    }
                    else
                    {
                        i--;
                    }
                }

                if (!rankFound)
                {
                    result.Add(1);
                }
            }


            return result;
        }
    }
}
