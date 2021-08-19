using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;

namespace Algorithm
{
   
    public class LinkedListNode
    {
        public int Value;
        public LinkedListNode NextNode;
        public LinkedListNode RandomNode;
        //public LinkedListNode(int value, LinkedListNode nextNode = null, LinkedListNode randomNode = null)
        //{
        //    this.Value = value;
        //    this.NextNode = nextNode;
        //}
        public LinkedListNode(int value, LinkedListNode nextNode = null,LinkedListNode randomNode=null)
        {
            this.Value = value;
            this.NextNode = nextNode;
            this.RandomNode = randomNode;
        }
        public static LinkedListNode ReverseKGroup(LinkedListNode root, int k)
        {

            LinkedListNode prev = null;
            LinkedListNode next = null;
            LinkedListNode current = root;
            LinkedListNode check = current;
            int c = 0;
            while (check != null)
            {
                c++;
                check = check.NextNode;
            }
            if (c < k)
            {
                return root;
            }
            c = 0;
            while (current != null && c < k)
            {
                next = current.NextNode;
                current.NextNode = prev;
                prev = current;
                current = next;
                c++;
            }
            if (next != null)
            {
                root.NextNode = ReverseKGroup(next, k);
            }
            return prev;
        }
        public static void ReverseLinkedList(ref LinkedListNode root)
        {
            LinkedListNode prev = null;
            LinkedListNode next = null;
            LinkedListNode current = root;

            while(current!=null)
            {
                next = current.NextNode;
                current.NextNode = prev;
                prev = current;
                current = next;
                if (current == null)
                    root = prev;
            }
      
        }
        public static LinkedListNode AddTwoLists(LinkedListNode first, LinkedListNode second)
        {
            int carry = 0;
            LinkedListNode result = null;
            LinkedListNode temp1 = first;
            LinkedListNode temp2 = second;
            LinkedListNode temp = null;
            int value = 0;
            int sum = 0;
            while (temp1 != null || temp2 != null || carry > 0)
            {
                int firstValue = temp1 == null ? 0 : temp1.Value;
                int secondValue = temp2 == null ? 0 : temp2.Value;
                temp1 = temp1 == null ? temp1 : temp1.NextNode;
                temp2 = temp2 == null ? temp2 : temp2.NextNode;
                sum = firstValue + secondValue + carry;
                carry = sum / 10;
                value = sum % 10;
                if (temp == null)
                    temp = new LinkedListNode(value);
                else
                {
                    temp.NextNode = new LinkedListNode(value);
                    temp = temp.NextNode;
                }
                if (result == null)
                    result = temp;
            }
            return result;
        }
        public static LinkedListNode AddTwoListsReversedCarry(LinkedListNode first, LinkedListNode second)
        {
            ReverseLinkedList(ref first);
            ReverseLinkedList(ref second);
            LinkedListNode result=AddTwoLists(first, second);
            ReverseLinkedList(ref result);
            return result;
        }

        public static LinkedListNode DeepCopyLinkedWithArbitraryNode(LinkedListNode root)
        {
            LinkedListNode copyList = null;
            LinkedListNode temp = root;
            LinkedListNode current = null;
            Hashtable hashTable = new Hashtable();
            while (temp!=null)
            {
                if (current == null)
                    current = new LinkedListNode(temp.Value, null, null);
                else
                {
                    current.NextNode = new LinkedListNode(temp.Value, null, null);
                    current = current.NextNode;
                }
                hashTable.Add(temp, current);
                if (copyList == null)
                    copyList = current;           
                temp = temp.NextNode;
            }

            LinkedListNode currentTemp = copyList;
            temp = root;
            while (currentTemp != null)
            {
                if(temp.RandomNode!=null)
                {
                    LinkedListNode randomNode = (LinkedListNode)hashTable[temp.RandomNode];
                    currentTemp.RandomNode = randomNode;
                }          
                currentTemp = currentTemp.NextNode;
                temp = temp.NextNode;
            }

            return copyList;
        }

        public bool DetectCyclicLoop(LinkedListNode root)
        {
            if (root != null)
            {
                LinkedListNode slowNode = root;
                LinkedListNode fastNode = root;
                while(slowNode!=fastNode && slowNode!=null && fastNode!=null && fastNode.NextNode != null)
                {
                    slowNode = slowNode.NextNode;
                    fastNode = fastNode.NextNode!=null ? fastNode.NextNode.NextNode: null;
                    if (slowNode==fastNode)
                    {
                        return true;                      
                    }
                }

                return false;
            }
            return false;
        }

        public void RemoveCyclicNode(LinkedListNode loop,LinkedListNode root)
        {
            LinkedListNode ptr1 = null, ptr2 = null;
            ptr1 = root;
            while (1 == 1)
            {
                ptr2 = loop;
                while (ptr2.NextNode != loop && ptr2.NextNode != ptr1)
                {
                    ptr2 = ptr2.NextNode;
                }
                if (ptr2.NextNode == ptr1)
                {
                    break;
                }
                ptr1 = ptr1.NextNode;
            }
            ptr2.NextNode = null;
        }

        public static LinkedListNode SwapPairs(LinkedListNode root)
        {
            return ReverseKGroup(root, 2);
        }
    }
}
