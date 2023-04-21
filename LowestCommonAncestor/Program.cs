using System;
using System.Collections.Generic;

namespace LowestCommonAncestor
{
    class Program
    {
        static void Main(string[] args)
        {
            // In this problem, we are going to find Lowest Common Ancestor of a binary tree.
            // First lets create the binary tree.
            // Create a list for the given input. (root = [3,5,1,6,2,0,8,null,null,7,4])
            List<object> rootValues = new() { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 };

            //Craete root node.
            TreeNode root = new(3);

            // Iterate over each root value and put them to the tree in each iteration. Start from 1 due to first is used to create root.
            for (int i = 1; i < rootValues.Count; i++)
            {
                object values = rootValues[i];
                int value;

                if (values != null)
                {
                    value = (int)values;
                }
                else
                {
                    value = 0;
                }
                CreateBinaryTree(root, value);
            }

            Console.WriteLine("Binary Tree is created.");

            #region Helper Function

            #region Create Binary Tree

            void CreateBinaryTree(TreeNode root, int value, int completedLeaf = default)
            {
                if (root.left != null && root.right != null)
                {
                    CreateBinaryTree(root.left, value);

                    if (completedLeaf == 1)
                    {
                        CreateBinaryTree(root.right, value);
                    }
                }

                if (root.left == null)
                {
                    
                        root.left = new TreeNode(value);
                    
                }
                else 
                {
                    if (root.right == null)
                    {
                            root.right = new TreeNode(value);
                        
                    }
                    else
                    {
                        completedLeaf = 1;
                    }
                }
            }

            #endregion

            #endregion
        }
    }

    //Create TreeNode
     public class TreeNode
     {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { val = x; }
     }
}
