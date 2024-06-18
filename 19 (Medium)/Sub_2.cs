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
        ListNode slow = new(-1, head);
        ListNode fast = head;
        int count = 0;
        while (fast.next != null)
        {
            fast = fast.next;
            count++;
            if (count >= n)
            {
                slow = slow.next;
            }
        }
        slow.next = slow.next.next;
        if (slow.val == -1) { return slow.next; }
        return head;
    }
}

// solution: 
// have the slow pointer trail behind the fast pointer by n+1 spots
// delay the incrementation of slow until fast increments n+1 times
// remove slow.next when fast.next is null

// problems:
// - how to remove first element (head must be shifted)
// - how to handle removal of length 1 array