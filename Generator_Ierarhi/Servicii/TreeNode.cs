using System;
using System.Collections.Generic;
using System.Text;

namespace Generator_Ierarhi.Servicii
{
    class TreeNode<T>
    {
        private T data = default;
        private TreeNode<T> left = null;
        private TreeNode<T> right = null;

        public T Data { get { return data; } set { data = value; } }
        public TreeNode<T> Left { get { return left; } set { left = value; } }
        public TreeNode<T> Right { get { return right; } set { right = value; } }
    }
}
