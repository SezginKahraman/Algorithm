using System;
using System.Collections.Generic;
using System.Linq;

namespace RansomNote
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
            Console.WriteLine(solution.RansomNote("aab", "aa"));
            
        }
    }

    public class Solution
    {
        public bool RansomNote(string magazine, string ransomnote)
        {

            Dictionary<char, int> hashTable = new();
            Dictionary<char, int> hashTableMagazine = new();

            for (int i = 0; i < ransomnote.Length; i++)
            {
                if (hashTable.ContainsKey(ransomnote[i]))
                {
                    hashTable[ransomnote[i]] = hashTable[ransomnote[i]] + 1;
                }
                else
                {
                    hashTable.Add(ransomnote[i], 1);
                }
            }
            for (int i = 0; i < magazine.Length; i++)
            {
                if (hashTableMagazine.ContainsKey(magazine[i]))
                {
                    hashTableMagazine[magazine[i]] = hashTableMagazine[magazine[i]] + 1;
                }
                else
                {
                    hashTableMagazine.Add(magazine[i], 1);
                }
            }
            foreach (var key in hashTable)
            {
                if (!hashTableMagazine.ContainsKey(key.Key))
                {
                    return false;
                }
                if (key.Value> hashTableMagazine[key.Key])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
