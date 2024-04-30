using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class TwoSums
    {
        // hashtable way
        public int[] TwoSum1(int[] nums, int target)
        {
            // 1, 2, 3, 4, 5
            // target - 6

            // result will be 2 + 4
            // time complexity - n^2
            // space complexity - n^2
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                int x = target - nums[i];

                if (hashtable.ContainsKey(x))
                {
                    int indexOfX = int.Parse(hashtable[x].ToString());
                    return new int[] { indexOfX, i };
                }
                else
                {
                    if (!hashtable.ContainsKey(nums[i]))
                    {
                        hashtable.Add(nums[i], i);
                    }
                }
            }

            return new int[0];
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            // 1, 2, 3, 4, 5
            // target - 6

            // result will be 2 + 4
            // time complexity - n^2
            // space complexity - n^2
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j
                        && nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[0];
        }

    }
}
