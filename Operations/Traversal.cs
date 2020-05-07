using BinaryTree.Models;
using System;
using System.Collections.Generic;

namespace BinaryTree.Operations
{
    public class Traversal
    {
        public IList<int> Preorder(TreeNode root)
        {
            var output = new List<int>();
            if (root == null) return output;
            output.Add(root.val);
            output.AddRange(Preorder(root.left));
            output.AddRange(Preorder(root.right));
            return output;
        }
        public IList<int> Inorder(TreeNode root)
        {
            var output = new List<int>();
            if (root == null) return output;
            output.AddRange(Inorder(root.left));
            output.Add(root.val);
            output.AddRange(Inorder(root.right));
            return output;
        }
        public IList<int> Postorder(TreeNode root)
        {
            var output = new List<int>();
            if (root == null) return output;
            output.AddRange(Postorder(root.left));
            output.AddRange(Postorder(root.right));
            output.Add(root.val);
            return output;
        }
        public void Print(TreeNode root, Ordering ordering)
        {
            IList<int> list;

            switch (ordering)
            {
                case Ordering.Pre:
                    list = Preorder(root);
                    break;
                case Ordering.In:
                    list = Inorder(root);
                    break;
                case Ordering.Post:
                    list = Postorder(root);
                    break;
                default:
                    list = new List<int>();
                    break;
            }

            Print(list);
        }
        public void Print<T>(IList<T> list)
        {
            var output = string.Empty;
            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            if (output.Length > 2) output = output.Substring(0, output.Length - 2);

            Console.WriteLine(output);
        }
        public enum Ordering
        {
            Pre, In, Post
        }
    }
}
