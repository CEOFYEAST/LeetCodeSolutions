/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution
{
    public bool HasCycle(ListNode head)
    {
        ListNode fast = head;

        while (head.next != null && head != null)
        {
            head = head.next;
            for (int i = 0; i < 2; i++)
            {
                if (fast.next == null) { return false; }

                fast = fast.next;
            }

            if (head == fast) { return true; }
        }

        return false;
    }
}

// first solution:
// slow pointer - point towards one cell at a time
// fast pointer - iterate through cells until either end is reached or slow pointer is reached
// doesn't work because if cell comes before loop, the loop is entered when checking if the cell is in the loop

// second solution:
// start at head.next and store head 

// cycle: when a node refers to itself or something before itself
// - basically just when the node ends up referring to itself because if the node can be reached, and it creates a cycle, it will inevitably end up referring to itself
// there's no way to tell if a node comes before another node in the list
// if I'm at a node, how can I tell that it creates a cycle?
// I have to check whether a node can be accessed and then reached again without getting stuck in the very cycle I'm looking for

// 