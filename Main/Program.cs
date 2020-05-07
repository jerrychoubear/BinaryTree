using BinaryTree.Models;
using BinaryTree.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = GenerateData(20, 10, 1);
            var insertion = new Insertion();
            var traversal = new Traversal();

            TreeNode root = insertion.Iterative(null, data);
            //root = insertion.Recursive(null, data);
            Console.WriteLine("Insertion:");
            traversal.Print(data);
            Console.WriteLine("Preorder:");
            traversal.Print(root, Traversal.Ordering.Pre);
            Console.WriteLine("Inorder:");
            traversal.Print(root, Traversal.Ordering.In);
            Console.WriteLine("Postorder:");
            traversal.Print(root, Traversal.Ordering.Post);

            Console.ReadLine();
        }

        static int[] GenerateData(int max, int count, int min)
        {
            var candidates = new HashSet<int>();
            var random = new Random();

            // start count values before max, and end at max
            for (int top = max - count; top < max; top++)
            {
                // May strike a duplicate.
                // Need to add +1 to make inclusive generator
                // +1 is safe even for MaxVal max value because top < max
                if (!candidates.Add(random.Next(min, top + 1)))
                {
                    // collision, add inclusive max.
                    // which could not possibly have been added before.
                    candidates.Add(top);
                }
            }

            return candidates.ToArray();
        }
    }
}
