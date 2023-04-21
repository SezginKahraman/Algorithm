using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a function that will create the below binary tree.
            //        15
            //       /  \
            //      8   25
            //     /   /  \
            //    7   20   30
            //              \
            //              40
            // After that write a function that will calculate the height of the binary tree. (Rule: smaller values are on the left side, bigger values are in the right according to the each node.)

            // First create a List that will contains the values of the binary tree.
            List<int> binaryValues = new() { 15, 8, 7, 25, 20, 30, 40 };

            // Create the root tree;
            TreeNode root = new(15);

            #region Simulation

            // Make a little simulation in order to understand the order of the algorithm which must be used.
            root.Right = new(25);
            root.Left = new(8);
            root.Left.Left = new(7);
            root.Right.Right = new(30);
            root.Right.Left = new(20);

            #endregion

            // Note: In a problem, if the root value is wanted NOT to be disappeared in the loop, i mean the root value is going to use in each iteration, give that root value outside of the Function !!!

            //Lets create the function.
            //First create the root node.
            TreeNode rootNode = new(binaryValues.FirstOrDefault());

            //Iterate over each values that will be put to the tree. Start from the second value due to first is used for the root.
            for (int value = 1; value < binaryValues.Count; value++)
            {
                // set each value.
                int values = binaryValues[value];

                // Call the function which puts each value to the right location in the tree.
                CreateBinaryTree(values, rootNode);
            }

            Console.WriteLine("** Binary Tree is Created !**");

            List<int> levelLists = new();
            int height = TreeHeightFunction(rootNode, 1, levelLists);

            Console.WriteLine(String.Format("The height of the tree is : {0}", height));
            // Let's create a function that will calculate the height of tree created.
            // We need to put to the storage the values which are already readed. 
            // For example in the, if we have already the node which has a value as 15, we will put that node to a list !.




            #region [Helper Functions]

            #region Create Tree Func

            void CreateBinaryTree(int value, TreeNode node)
            {
                //Check if the value is bigger
                if (value < node.Value)
                {
                    //If there is a node in the left edge, give that node to the function again.    
                    if (node.Left != null)
                    {
                        // set node as the left of the node and recall the function
                        node = node.Left;
                        CreateBinaryTree(value, node);
                    }
                    else
                    {
                        // If there is no more node, set the value to the tree.
                        node.Left = new TreeNode(value);
                    }
                }
                else
                {
                    if (node.Right != null)
                    {
                        node = node.Right;
                        CreateBinaryTree(value, node);
                    }
                    else
                    {
                        node.Right = new TreeNode(value);
                    }
                }
            }

            #endregion

            #region Calculate Height

            int TreeHeightFunction(TreeNode rootNode, int level = default, List<int> levelLists = default)
            {

                if (rootNode.Left != null)
                {
                    TreeHeightFunction(rootNode.Left, level + 1, levelLists);
                }

                if (rootNode.Right != null)
                {
                    TreeHeightFunction(rootNode.Right, level + 1, levelLists);
                }

                levelLists.Add(level);

                return levelLists.Max();
            }

            #endregion

            #endregion
        }
    }

    #region [ Tree Class ]

    class TreeNode
    {
        public int Value { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public TreeNode(int value = default)
        {
            // The reason why i made ctor block is that, to match Value prop without making an instance of that class
            this.Value = value;
        }
    }

    #endregion
}
