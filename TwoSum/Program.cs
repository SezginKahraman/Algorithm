using System;
using System.Collections.Generic;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Solution solution = new(); // LeetCode Problem
            solution.TwoSum(new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11);
        }
    }
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> hashTable = new();
            for (int i = 0; i < nums.Length; i++)
                if (hashTable.ContainsKey(nums[i]))
                {
                    return new List<int> { hashTable[nums[i]], i }.ToArray();
                }
                else
                {
                    int tryValue = target - nums[i];
                    if (hashTable.ContainsKey(tryValue))
                    {
                        continue;
                    }
                    hashTable.Add(tryValue, i);
                }

            return new int[] { 0 };
        }
    }
}
