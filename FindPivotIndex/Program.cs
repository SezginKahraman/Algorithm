using System;
using System.Collections.Generic;
using System.Linq;

namespace FindPivotIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given an array of integers nums, calculate the pivot index of this array.
            // The pivot index is the index where the sum of all the numbers strictly to the left of the index is equal to the sum of all the numbers     strictly to the index's right.
            // If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the  right edge of the array.
            // Return the leftmost pivot index.If no such index exists, return -1.
            Solution solution = new();
            solution.PivotIndex(new int[]{ 1, 7, 3, 6, 5, 6 });

        }
    }

    public class Solution
    {
        public int PivotIndex(int[] nums)
        {
            // First, be aware that, if you know the sum of the array and the location of the sum, you actaully know the rest sum.
            // For instance, lets say, if you know the nums sum which is 28, and you know the 1+7+3, actually you can find,
            // 6+5+6 by using = sum - (1+7+3);

            Dictionary<int, int> hashTable = new();
            int sumOfArray = nums.Sum();
            int sumOfIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];

                // The hash table could be removed in this solution.
                if (i > 0)
                {
                    if (hashTable.ContainsKey(i - 1))
                    {
                        sumOfIndex = hashTable[i - 1];
                    }
                }

                int checkPivot = sumOfArray - sumOfIndex - num;
                if (checkPivot == sumOfIndex)
                {
                    return i;
                }
                sumOfIndex += num;
                hashTable.Add(i,sumOfIndex);
            }

            return -1;

            // This solution can be optimized by using arrays instead of dictionary, use a for loop for to calculate sum instead of built-in function.
            // int[] numArray = new int[nums.Length];  default values are [0,0,0,0 ].
        }
    }
}
