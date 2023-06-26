using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelOrder
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create the binary tree
            var tree = new LevelOrder();

            // send tree to the function that will calculate the level of the tree
            var level = CalculateTree(tree.BinaryTree);

            Console.WriteLine(level);

            List<List<int>> CalculateTree(Tree tree, int level = default, Dictionary<int, List<int>> orderList = default)
            {
                if(tree == null)
                {
                    return default;
                }

                if (level == default)
                {
                    orderList = new Dictionary<int, List<int>>();
                }

                if (!orderList.ContainsKey(level))
                {
                    orderList.Add(level, new List<int> { tree.Value });
                }
                else
                {
                    orderList[level].Add(tree.Value);
                }
                
                if (tree.Right != null)
                {
                    CalculateTree(tree.Right, level + 1, orderList);
                }

                if (tree.Left != null)
                {
                    CalculateTree(tree.Left, level + 1, orderList);
                }

                var returnValue = new List<List<int>>();

                if (level == default) 
                {
                    foreach (var item in orderList)
                    {
                        returnValue.Add(item.Value);
                    }
                }   
                return returnValue;
            }
        }
    }

    public class LevelOrder
    {
        public int Level{ get; set; }

        public Tree BinaryTree{ get; set; }

        public List<List<int>> LevelList { get; set; }

        public LevelOrder()
        {
            var tree = new Tree(3);
            tree.Left = new Tree(9);
            tree.Right = new Tree(20);
            tree.Right.Right = new Tree(7);
            tree.Right.Left = new Tree(15);
            this.BinaryTree = tree;
        }
    }

   public class Tree
    {
        public Tree(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        
        public Tree Right{ get; set; }

        public Tree Left { get; set; }
    }
}
