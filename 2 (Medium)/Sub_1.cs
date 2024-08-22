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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode head = new(0, null);
        ListNode current = new(0, head);
        bool carry = false;
        while (l1 != null || l2 != null || carry)
        {
            if (current.next == null)
            {
                current.next = new(0, null);
            }

            current = current.next;

            int sum = 0;

            if (carry)
            {
                sum++;
                carry = false;
            };

            if (l1 != null)
            {
                sum += l1.val;
                l1 = l1.next;
            }
            if (l2 != null)
            {
                sum += l2.val;
                l2 = l2.next;
            }

            if (sum > 9)
            {
                carry = true;
                sum -= 10;
            }

            current.val = sum;
        }

        return head;
    }
}

/**
Problem Info:
input: 
- two non-empty linked lists
- they represent two non-negative integers
- digits stored in reverse order
    - the integer, but reversed
- each node contains single digit >= 0
- read-only

output:
- the reversed sum of the two integers
- read and write

logic: 
- extract integers from input
- add integers
- return integer as linked list in reverse order

reverse order definition:
- the head points to the last digit of the integer, or the tens spot

edge cases:
- one or both inputs are zero (in which case there would only be one digit)

brute force:
- assemble both integers seperately, add them together, create toReturn

oppurtunities arrising from reverse order
- could traverse both lists at the same time, perform simple addition, making sure to carry if neccesary, and add the     result for each digit to the list once it's been calculated

additional notes
- result should never be larger than 19
- carry number should never be larger than 1, so can be represented by boolean

steps
- initialize toReturn
- iterate over both lists until they individually terminate (could be at different times)
- add numbers from both lists, factoring in carry-number from last iteration
- save new carry number if result >= 10

problems
- didn't account for carry after loop exit
- wasn't careful about when to create another node
- ran into issues with linked-list traversal

improvements
- originally I set the input lists to dummies, checked if the input lists' next values were null, and then iterated and added the value of next
    - using dummies was pointless, though, because I could just check if the nodes themselves were null, and then just not access them in that case
- should only use dummy node when first node is manipulated
    - otherwise, first node acts as special case
*/