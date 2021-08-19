using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{

    public class BinarySearchTree
    {
        public BinaryTreeNode Root;
        public string Name { get; set; }
        public BinarySearchTree(string name)
        {
            Name = name;
            Root = null;
        }
        public void InsertNode(int data, string description)
        {
            InsertNode(data, description, ref Root);
        }
        private void InsertNode(int data, string description, ref BinaryTreeNode currentNode)
        {
            if (currentNode == null)
            {
                currentNode = new BinaryTreeNode(data, description);
                if (Root == null)
                    Root = currentNode;
                return;
            }

            if (data < currentNode.Data)
            {
                InsertNode(data, description, ref currentNode.LeftNode);
                return;
            }
            else
            {
                InsertNode(data, description, ref currentNode.RightNode);
                return;
            }

        }
        public BinaryTreeNode DeleteNode(int data)
        {
            return DeleteNode(data, ref Root);
        }
        private BinaryTreeNode DeleteNode(int data, ref BinaryTreeNode currentNode)
        {
            if (currentNode == null) return currentNode;
            if (data < currentNode.Data)
                currentNode.LeftNode = DeleteNode(data, ref currentNode.LeftNode);
            else if (data > currentNode.Data)
                currentNode.RightNode = DeleteNode(data, ref currentNode.RightNode);
            else
            {
                if (currentNode.LeftNode == null)
                    return currentNode.RightNode;
                else if (currentNode.RightNode == null)
                    return currentNode.LeftNode;
                currentNode.Data = GetMin(ref currentNode.RightNode).Data;
                currentNode.RightNode = DeleteNode(currentNode.Data, ref currentNode.RightNode);
            }
            return currentNode;
        }
        public BinaryTreeNode Search(int data)
        {
            return Search(data, ref Root);
        }
        private BinaryTreeNode Search(int data, ref BinaryTreeNode currentNode)
        {
            if (currentNode == null)
            {
                throw new Exception("The desirded data didnot exist");
            }
            if (currentNode.Data == data)
            {
                return currentNode;
            }
            else if (data < currentNode.Data)
            {
                return Search(data, ref currentNode.LeftNode);
            }
            else
            {
                return Search(data, ref currentNode.RightNode);
            }
        }
        public BinaryTreeNode GetMin()
        {
            return GetMin(ref Root);
        }
        private BinaryTreeNode GetMin(ref BinaryTreeNode currentNode)
        {
            if (currentNode.LeftNode != null)
            {
                return GetMin(ref currentNode.LeftNode);

            }
            else
            {
                return currentNode;
            }
        }
        public BinaryTreeNode GetMax()
        {
            return GetMax(ref Root);
        }
        private BinaryTreeNode GetMax(ref BinaryTreeNode currentNode)
        {
            if (currentNode.RightNode != null)
            {
                return GetMax(ref currentNode.RightNode);
            }
            else
            {
                return currentNode;
            }
        }
        public int GetHeight(BinaryTreeNode? node)
        {
            if (node == null)
                return GetNodeHeight(Root) - 1;
            else
                return GetNodeHeight(node) - 1;
        }
        public int GetMaxDepth()
        {
            return GetNodeHeight(Root) - 1;
        }
        private int GetNodeHeight(BinaryTreeNode node)
        {
            if (node == null) return 0;
            int leftDepth = GetNodeHeight(node.LeftNode);
            int rightDepth = GetNodeHeight(node.RightNode);
            return Math.Max(leftDepth, rightDepth) + 1;
        }
        public void Inorder()
        {
            Inorder(ref Root);
        }
        public void Preorder()
        {
            Preorder(Root);
        }
        public void Postorder()
        {
            Postorder(ref Root);
        }
        private void Inorder(ref BinaryTreeNode currentNode)
        {
            if (currentNode != null)
            {
                Inorder(ref currentNode.LeftNode);
                Console.WriteLine(currentNode.Data);
                Inorder(ref currentNode.RightNode);
            }
        }
        private void Preorder(BinaryTreeNode currentNode)
        {
            if (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                Preorder(currentNode.LeftNode);
                Preorder(currentNode.RightNode);
            }
        }
        private void Postorder(ref BinaryTreeNode currentNode)
        {
            if (currentNode != null)
            {
                Postorder(ref currentNode.LeftNode);
                Postorder(ref currentNode.RightNode);
                Console.WriteLine(currentNode.Data);
            }
        }
        public bool IsBST()
        {
            //return IsBST(Root);
            return IsBSTBest(Root, int.MinValue, int.MaxValue);
        }
        private bool IsBST(BinaryTreeNode node)
        {

            if (node == null)
                return true;
            if (node.LeftNode != null && GetMax(ref node.LeftNode).Data > node.Data)
                return false;
            if (node.RightNode != null && GetMin(ref node.RightNode).Data < node.Data)
                return false;
            if (!IsBST(node.LeftNode) || !IsBST(node.RightNode))
                return false;
            return true;
        }
        private bool IsBSTBest(BinaryTreeNode node,int min,int max)
        {

            if (node == null)
                return true;
            if (node.Data < min || node.Data > max)
            {
                return false;
            }
            return (IsBSTBest(node.LeftNode, min, node.Data - 1) && IsBSTBest(node.RightNode, node.Data + 1, max));
        }
        private bool IsBalanced(BinaryTreeNode node)
        {
            if (node == null)
                return true;
            if ((GetNodeHeight(node.LeftNode) - GetNodeHeight(node.RightNode)) > 1)
                return false;         
            return (IsBalanced(node.LeftNode) && IsBalanced(node.RightNode));
        }
        public void ConnectSameLevelNodes()
        {
            ConnectSameLevelNodes(Root);
        }
        private void ConnectSameLevelNodes(BinaryTreeNode node)
        {
            if (node == null) return;
            Queue<BinaryTreeNode> currentQueue = new Queue<BinaryTreeNode>();
            Queue<BinaryTreeNode> nextQUeue = new Queue<BinaryTreeNode>();
            currentQueue.Enqueue(Root);
            while (currentQueue.Count > 0)
            {
                BinaryTreeNode tempNode = currentQueue.Dequeue();
                if (tempNode.LeftNode != null)
                    nextQUeue.Enqueue(tempNode.LeftNode);
                if (tempNode.RightNode != null)
                    nextQUeue.Enqueue(tempNode.RightNode);
                tempNode.RightNode= currentQueue.Count>0?currentQueue.Peek():null;
                if (currentQueue.Count == 0)
                {
                    currentQueue = nextQUeue;
                    nextQUeue = new Queue<BinaryTreeNode>();
                }
            }
        }
        public void ConnectSiblingsTraverse()
        {
            ConnectSiblingsTraverse(ref Root);

            Console.WriteLine(Root.RightNode.RightNode.Next.Data);
        }
        private void ConnectSiblingsTraverse(ref BinaryTreeNode node)
        {
            if (node == null) return;
            Queue<BinaryTreeNode> currentQueue = new Queue<BinaryTreeNode>();
            Queue<BinaryTreeNode> nextQueue = new Queue<BinaryTreeNode>();
            currentQueue.Enqueue(Root);
            while (currentQueue.Count > 0)
            {
                BinaryTreeNode tempNode = currentQueue.Dequeue();
                if (tempNode.LeftNode != null)
                    nextQueue.Enqueue(tempNode.LeftNode);
                if (tempNode.RightNode != null)
                    nextQueue.Enqueue(tempNode.RightNode);
                tempNode.Next = currentQueue.Count>0?currentQueue.Peek(): nextQueue.Count>0 ? nextQueue.Peek():null;
                if(tempNode.Next!=null)
             //   Console.WriteLine($"{tempNode.Data} {tempNode.Next.Data}");
                if (currentQueue.Count == 0)
                {
                    currentQueue = nextQueue;
                    nextQueue = new Queue<BinaryTreeNode>();
                }
            }
        }
        public void LevelOrderTraversal()
        {
            LevelOrderTraversal(Root);
        }
        private void LevelOrderTraversal(BinaryTreeNode node)
        {
            if (node == null) return;
            string singleLineResult = string.Empty;
            Queue<BinaryTreeNode> currentQueue = new Queue<BinaryTreeNode>();
            Queue<BinaryTreeNode> nextQUeue = new Queue<BinaryTreeNode>();
            currentQueue.Enqueue(Root);
            while(currentQueue.Count>0)
            {
                BinaryTreeNode tempNode = currentQueue.Dequeue();
                singleLineResult = $"{singleLineResult}{tempNode.Data}";
                if (tempNode.LeftNode!=null)
                nextQUeue.Enqueue(tempNode.LeftNode);
                if (tempNode.RightNode != null)
                nextQUeue.Enqueue(tempNode.RightNode);
                if(currentQueue.Count==0)
                {
                    currentQueue = nextQUeue;
                    nextQUeue = new Queue<BinaryTreeNode>();                
                    Console.WriteLine(singleLineResult);
                    singleLineResult = string.Empty; 
                }
                else
                {
                    singleLineResult =$"{singleLineResult},";
                }
            }  
            
        }
        public int LCA(int n1,int n2)
        {
            int lcaValue = -1;
            List<int> n1Ancestors = new List<int>();
            List<int> n2Ancestors = new List<int>();
            n1Ancestors.Add(Root.Data);
            n2Ancestors.Add(Root.Data);
            BinaryTreeNode leftPath = Root.LeftNode;
            BinaryTreeNode rightPath = Root.RightNode;
            while(leftPath!=null)
            {
                n1Ancestors.Add(leftPath.Data);
                if (LeastCommonAncestor(leftPath, n1))
                    break;
                leftPath = leftPath.LeftNode;
            }
            while (rightPath != null)
            {
                n2Ancestors.Add(rightPath.Data);
                if (LeastCommonAncestor(rightPath, n2))
                    break;
                rightPath = rightPath.RightNode;
            }
            int i = 0;
            while(i< n1Ancestors.Count && i < n2Ancestors.Count && n1Ancestors[i]==n2Ancestors[i])
            {
                lcaValue = n1Ancestors[i];
                i++;             
            }
            return lcaValue;
        }
        private bool LeastCommonAncestor(BinaryTreeNode root,int n)
        {
            if (root.LeftNode != null)
            {
                if (root.LeftNode.Data == n)
                {
                    return true;
                }
              
            }
            if(root.RightNode!=null)
            {
                if (root.RightNode.Data == n)
                {
                    return true;
                }

            }          
            return false;

        }
    }

    public class BinaryTreeNode
    {
        public int Data;
        public BinaryTreeNode LeftNode;
        public BinaryTreeNode RightNode;
        public BinaryTreeNode Next;
        public string Description;
        public BinaryTreeNode(int data,string description)
        {
            Data = data;
            LeftNode = null;
            RightNode = null;
            Next = null;
            Description = description;
        }
    }
}
