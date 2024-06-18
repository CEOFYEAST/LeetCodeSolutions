using System;
using System.Collections.Generic;

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode dummy = new(0, head);
        ListNode slow = dummy;
        int count = 0;
        while (head.next != null)
        {
            head = head.next;
            count++;
            if (count >= n)
            {
                slow = slow.next;
            }
        }
        slow.next = slow.next.next;
        return dummy.next;
    }
}

// solution: 
// interesting dummy solution, where if the head is being removed, the slow pointer ends up pointing to the dummy node, and the dummy node's next is the head
// the dummy node will always point to the head by the end because if slow points to the dummy node, then the dummy node's next will be set to the new head

// problems with solution:
// the iterating logic in the program isn't very simple; its all combined into one messy loop
// its not particularly performant, or memory efficient

// things I like about solution:
// its cool