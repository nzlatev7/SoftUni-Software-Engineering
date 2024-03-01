using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    class Lake : IEnumerable<int>
    {
        private List<int> oddNums;
        private List<int> evenNums;
        public Lake(List<int> nums)
        {
            oddNums = new List<int>();
            evenNums = new List<int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (i % 2 == 0)
                {
                    evenNums.Add(nums[i]);
                }
                else
                {
                    oddNums.Add(nums[i]);
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in evenNums)
            {
                yield return item;
            }
            for (int i = oddNums.Count - 1; i >= 0; i--)
            {
                yield return oddNums[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
