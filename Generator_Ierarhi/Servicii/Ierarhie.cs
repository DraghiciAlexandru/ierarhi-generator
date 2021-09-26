using Generator_Ierarhi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generator_Ierarhi.Servicii
{
    class Ierarhie<T> where T : IComparable<T>
    {
        public TreeNode<T> root;

        public Ierarhie(T data)
        {
            root = new TreeNode<T> { Data = data, Left = null, Right = null };
        }

        public TreeNode<T> find(TreeNode<T> node, T data)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Data.Equals(data))
            {
                return node;
            }

            TreeNode<T> left= find(node.Left, data);

            if (left != null)
            {
                return left;
            }


            return find(node.Right, data);
        }

        public bool addSubordinate(T manager, T subordonat)
        {
            TreeNode<T> node = find(root, manager);

            if (node == null)
            {
                return false;
            }

            if (node.Left != null && node.Right != null)
            {
                return false;
            }

            if (node.Left == null)
            {
                node.Left = new TreeNode<T> { Data = subordonat, Left = null, Right = null };
                return true;
            }
            else
            {
                node.Right = new TreeNode<T> { Data = subordonat, Left = null, Right = null };
                return true;
            }
        }

        public void afisare()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                if (queue.Peek().Left != null) 
                {
                    queue.Enqueue(queue.Peek().Left);
                }
                if (queue.Peek().Right != null) 
                {
                    queue.Enqueue(queue.Peek().Right);
                }

                Console.Write(queue.Peek().Data);

                queue.Dequeue();
            }
        }

        public override string ToString()
        {
            String text = "";

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                if (queue.Peek().Left != null)
                {
                    queue.Enqueue(queue.Peek().Left);
                }
                if (queue.Peek().Right != null)
                {
                    queue.Enqueue(queue.Peek().Right);
                }

                Person person = queue.Peek().Data as Person;

                text += "," + person.Id;

                queue.Dequeue();
            }

            return text;
        }
    }
}
