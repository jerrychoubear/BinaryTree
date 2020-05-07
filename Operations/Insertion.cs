using BinaryTree.Models;
using System;
using System.Diagnostics;

namespace BinaryTree.Operations
{
    public class Insertion
    {
        Stopwatch _stopwatch;

        public Insertion()
        {
            _stopwatch = new Stopwatch();
        }

        public TreeNode Recursive(TreeNode root, params int[] vals)
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            foreach (var val in vals)
            {
                root = Recursive(root, val);
            }
            _stopwatch.Stop();
            Console.WriteLine($"TotalMilliseconds used with {nameof(Recursive)}: {_stopwatch.Elapsed.TotalMilliseconds}");
            return root;
        }
        public TreeNode Iterative(TreeNode root, params int[] vals)
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            foreach (var val in vals)
            {
                root = Iterative(root, val);
            }
            _stopwatch.Stop();
            Console.WriteLine($"TotalMilliseconds used with {nameof(Iterative)}: {_stopwatch.Elapsed.TotalMilliseconds}");
            return root;
        }
        private TreeNode Recursive(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);
            if (root.val > val) root.left = Recursive(root.left, val);
            if (root.val < val) root.right = Recursive(root.right, val);
            return root;
        }
        private TreeNode Iterative(TreeNode root, int val)
        {
            var newNode = new TreeNode(val);
            if (root == null) return newNode;

            var head = root;
            var current = root;
            while (current != null)
            {
                head = current;
                current = current.val > newNode.val
                    ? current.left
                    : current.right;
            }
            if (head.val > newNode.val)
            {
                head.left = newNode;
            }
            if (head.val < newNode.val)
            {
                head.right = newNode;
            }
            return root;
        }
    }
}
