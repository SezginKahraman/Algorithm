using System;
using System.Collections.Generic;

namespace RunningSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {

        public int[] RunningSum(int[] nums)
        {
            Dictionary<int, int> hashTable = new();

            List<int> returnList = new();

            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {

                int value = nums[i];

                if (i > 0)
                {

                    if (hashTable.ContainsKey(i - 1))
                    {

                        sum = hashTable[i - 1];

                    }

                }

                sum += value;

                hashTable.Add(i, sum);

                returnList.Add(sum);

            }

            return returnList.ToArray();
        }

    }
}
