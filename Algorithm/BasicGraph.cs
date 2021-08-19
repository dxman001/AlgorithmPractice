using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public class BasicGraph
    {
        private int TotalNodes { get; set; }
        private LinkedListNode[] LinkedListArray { get; set; }
        public BasicGraph(int totalNodes)
        {
            TotalNodes = totalNodes;
            LinkedListArray = new LinkedListNode[TotalNodes];
            for(int i=0;i<TotalNodes;i++)
            {
                LinkedListArray[i] = new LinkedListNode(i);
            }
        }
        public void AddEdges(int node,int adNode)
        {
            LinkedListNode toBeAddedNode = new LinkedListNode(adNode);
            AddNode(LinkedListArray[node], toBeAddedNode);
            
        }
        private void AddNode(LinkedListNode root, LinkedListNode adNode)
        {
            var tempNode = root;
            while (tempNode.NextNode != null)
            {
                tempNode = tempNode.NextNode;
            }
            tempNode.NextNode = adNode;
        }

        public void PrintAdjucencyList()
        {
            for(int i=0;i<TotalNodes;i++)
            {
                string result = "";
                result += $"Node {i} is Neboure with : ";
                LinkedListNode currentNode = LinkedListArray[i].NextNode;
                while(currentNode!=null)
                {
                    result += $"{currentNode.Value}";
                    currentNode = currentNode.NextNode;
                    if (currentNode != null)
                        result += " -> ";
                }
                Console.WriteLine(result);
            }
        }



    }
}
