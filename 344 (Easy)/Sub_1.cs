
Runtime: Beats 97.61 % of submissions @ 203 milliseconds
Memory: Beats 54.97% of submissions @ 129.26 megabytes

public class Solution
{
    public void ReverseString(char[] s)
    {
        for (int i = 0; i < s.Length / 2; i++)
        {
            int l = s.Length - 1 - i;
            char temp = s[i];
            s[i] = s[l];
            s[l] = temp;
        }
    }
}

/**
Problem Info: 
- Must use in-place modification
- Must reverse a given string, supplied in the form of an array of characters
- Array has length >= 1

Starting Info:
- use running from both ends of array approach

Input Edge Cases:
- Array has length 1
    - array is simply returned

Input Base Cases:
- (1) Array has even length
    - Every character will be swapped with another character at some point
- (2) Array has odd length
    - There will be a middle character that won't be swapped

Thinking Through Solution:
- There will be lots of character swapping
    - Specifically int( array length / 2 ) swaps 
- What values will be swapped?
    - Only two values the same distance away from their respective side of the array will be swapped
- Both base cases can be treated the same because the same number of swaps will happen whether the input has 4 or five characters

Potential Optimizations:
- Analyzing this post-submission, its clear that the runtime is insanely fast, beating 97.61 percent of submissions
- However, the memory efficiency could be a bit better
    - I believe the only reason its slightly bad is because I store a calculation in a variable; however, this decision should boost runtime speed
- Another thing I noticed is that I calculate the value of l every time the loop runs; instead, I could update l along 
  with the loop to avoid all those costly calculations
*/