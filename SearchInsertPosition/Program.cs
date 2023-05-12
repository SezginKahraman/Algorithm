using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace SearchInsertPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            //Given a sorted array of distinct integers and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.

            //You must write an algorithm with O(log n) runtime complexity.

            // Create the instance of solution object
            Solution solution = new();

            // Create the nums for test
            int[] nums = { 1, 3,5,6 };

            // Give the target and list that will be searched to the function.
            solution.SearchPosition(nums, 7);
        }
    }
    public class Solution
    {
        public int SearchPosition(int[] nums, int target)
        {
            // The problem gives an sorted array. !
            // The key point is that, if an array is sorted, it doesnt matter if it is int array or not, the key point might be using the binary search.

            // What binary search is that, searching the array by dividing it in each iteration and search on of its divided component. It is known that the target value is either greater or lower than the boundries of that two divided component, so which component will be searched is known.
            // For example, think that we have an array like {1,4,6,8,10} and searching the target 8.
            // First check if the middle value, which is 6 is greater or lower than 8. In this example it is greater so check the {6,8,10}. Again repeat, check the middle value which is 8, equal, greater or lower. Equal, so break the iteration.
            // Let's code the algorithm.

            int rightIndex = nums.Length -1 ; // Set the right index as starting point
            int leftIndex = 0;            // Set the left index
            int middleValueIndex = 0;
            while (rightIndex >= leftIndex) // The iteration count is now known, so while loop is more logical
            {
                // Set the middle value
                middleValueIndex = (leftIndex + rightIndex) / 2; // the values are int, so it will floor if the nums has odd number of elements.

                int middleValue = nums[middleValueIndex]; // Set the middleValue
                if (middleValue == target) // Check and return if the middle is equal to target
                {
                    return middleValueIndex;
                }
                if (middleValue > target) // if middle is bigger, set right -1 as right.
                {
                    rightIndex = middleValueIndex -1;
                }
                if (middleValue < target) // if the middle is lower , set it as left.
                {
                    leftIndex = middleValueIndex + 1;
                }
            }
            if (nums[middleValueIndex] > target) //lastly check if the target is outside of the list.
            {
                return middleValueIndex; // if not is outside, return index.
            }
            return middleValueIndex + 1; // if it is outside, return by adding one
        }
    }
}