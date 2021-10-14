using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Generator_Ierarhi.Servicii
{
    class BST<T> where T : IComparable<T>
    {
        private TreeNode<T> root = null;

        public TreeNode<T> Root
        {
            get { return root; }
        }

        private void insert(TreeNode<T> node, T data)
        {
            if (node.Data.CompareTo(data) < 0)
            {

                if (node.Right == null)
                {

                    node.Right = new TreeNode<T> { Data = data, Left = null, Right = null };
                }
                else
                {

                    insert(node.Right, data);
                }
            }
            else
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode<T> { Data = data, Left = null, Right = null };
                }
                else
                {
                    insert(node.Left, data);
                }
            }


        }

        public void insert(T data)
        {
            if (root == null)
            {
                root = new TreeNode<T> { Data = data, Left = null, Right = null };
            }
            else
            {
                insert(root, data);
            }
        }

        public override string ToString()
        {
            String text = "";

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                if (queue.Peek().Left != null)
                {
                    queue.Enqueue(queue.Peek().Left);
                }
                if (queue.Peek().Right != null)
                {
                    queue.Enqueue(queue.Peek().Right);
                }

                text += queue.Dequeue().Data.ToString() + ";";
            }

            return text;
        }

        public void preorder(TreeNode<T> node)
        {

            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Data);

            preorder(node.Left);
            preorder(node.Right);

        }

        public void inorder(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            inorder(node.Left);

            Console.WriteLine(node.Data);

            inorder(node.Right);
        }

        public void postorder(TreeNode<T> node) 
        {
            if (node == null)
            {
                return;
            }

            postorder(node.Left);
            postorder(node.Right);
            Console.WriteLine(node.Data);
        }

        public TreeNode<T> find(TreeNode<T> node, T data)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Data.Equals(data))
            {
                return node;
            }
            else if (node.Data.CompareTo(data) == 1)
            {
                return find(node.Left, data);
            }
            else
            {
                return find(node.Right, data);
            }
        }

        public TreeNode<T> succesor(TreeNode<T> node)
        {
            TreeNode<T> current = node.Right;

            while (current != null && current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        public TreeNode<T> delete(TreeNode<T> start, T data)
        {
            if (start == null)
            {
                return null;
            }
            if (data.CompareTo(start.Data) < 0)
            {
                start.Left = delete(start.Left, data);
            }
            else if (data.CompareTo(start.Data) > 0)
            {
                start.Right = delete(start.Right, data);
            }
            else
            {
                if (start.Left == null)
                {
                    TreeNode<T> tmp = start.Right;

                    start = null;

                    return tmp;


                }

                if (start.Right == null)
                {
                    TreeNode<T> tmp = start.Left;

                    start = null;

                    return tmp;

                }

                TreeNode<T> succ = succesor(start);

                start.Data = succ.Data;

                start.Right = delete(start.Right, succ.Data);
            }
            return start;
        }
    }
}