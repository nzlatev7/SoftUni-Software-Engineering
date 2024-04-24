using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class RemoveDuplicatesSortedList
    {
        // Given the head of a sorted linked list, delete all duplicates such that each element appears only once.
        // Return the linked list sorted as well.
        public static ListNode DeleteDuplicates(ListNode head)
        {
            List<int> uniqueValues = new List<int>();

            // [1,1,2,3,3] -> [1,2,3]
            ListNode newNode = new ListNode();

            //Queue<ListNode> listNodes = new Queue<ListNode>();
            for (ListNode node = head; node != null; node = node.next)
            {
                if (uniqueValues.Contains(node.val))
                {
                    continue;
                }

                uniqueValues.Add(node.val);
            }

            int n = uniqueValues.Count;
            ListNode root = ArrayToList(uniqueValues, n);

            return root;
        }

        static ListNode ArrayToList(List<int> vals, int n)
        {
            ListNode root = null;
            for (int i = 0; i < n; i++)
                root = Insert(root, vals[i]);
            return root;
        }
        static ListNode Insert(ListNode root, int item)
        {
            ListNode temp = new ListNode();
            ListNode ptr;
            temp.val = item;
            temp.next = null;

            if (root == null)
                root = temp;
            else
            {
                ptr = root;
                while (ptr.next != null)
                    ptr = ptr.next;
                ptr.next = temp;
            }
            return root;
        }
    }

    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
