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
        if (head.next == null) { return null; }

        ListNode slow = null;
        ListNode fast = head;
        int count = 0;
        while (fast.next != null)
        {
            count++;

            fast = fast.next;

            if (count == n) { slow = head; }

            if (count > n)
            {
                //if(slow == null){ slow = head; }

                slow = slow.next;
            }
        }

        if (slow == null) { return head.next; }

        slow.next = slow.next.next;

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