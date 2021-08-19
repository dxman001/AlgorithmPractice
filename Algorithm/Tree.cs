using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public class Tree<T>
    {
      public TreeNode<T> Root { get; set; }
    }
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Childrens { get; set; }

        public TreeNode()
        {
        }
        public TreeNode(T data,TreeNode<T> parent,List<TreeNode<T>> childerens)
        {
            Data = data;
            Parent = parent;
            Childrens = childerens;
        }

        public int GetDepth()
        {
            int depth = 0;
            var current = this;
            while(current.Parent!= null)
            {
                depth++;
                current = current.Parent;
            }
            return depth;
        }
    }
}
