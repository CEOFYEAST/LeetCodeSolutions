public class Solution
{
    public void NextPermutation(int[] nums)
    {
        // nums has only one permutation
        if (nums.Length == 1)
        {
            return;
        }

        // find swap that incurs smallest possible lex. increase
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            for (int l = nums.Length - 1; l > i; l--)
            {
                if (nums[i] < nums[l])
                { // a swap can be made, aka a "next" perm. exists
                    // make swap
                    int temp = nums[i];
                    nums[i] = nums[l];
                    nums[l] = temp;

                    // sort numbers after l-index in ascending order (smallest possible lex.)
                    for (int x = i + 1; x < nums.Length; x++)
                    {
                        int y = x + 1;
                        while (y != nums.Length)
                        {
                            // restart loop if swap is made
                            if (nums[y] < nums[x])
                            {
                                // make swap
                                temp = nums[x];
                                nums[x] = nums[y];
                                nums[y] = temp;
                                y = x;
                            }

                            y++;
                        }
                    }

                    return;
                }
            }
        }

        // nums has no "next" permutation
        Array.Sort(nums);
        return;
    }
}

/**
Problem Info:
- permutation is a single arrangement of the members of a collection
    - must be a sequence/linear
- the "next" permutation of a sequence is the next lexicorographically greater permutation
    - aka the next-smallest permutation
- must find "next" permutation of given integer array
- if "next" permutation does not exist, arrange as lowest possible lexicorographic value
    - arrange in ascending order
- array has atleast one element
- array elements are >= 0 & <= 100

Prior Knowledge:
- use "running from both ends of array" approach

Considerations:
- how is lexi. value of an integer determined?
    - sort uses lex. values
    - Compare() compares two integers for lex. value
- is it easy to determine lexi. value of a whole set?
    - integers could all be combined into one string and then that string could be used

Input Cases:
    Base Case:
    - given array has length > 1, and has next permutation

    Edge Cases:
    - given array has length of 1
        - return array
    - given array has no "next" permutation, 
        - return smallest lex. arrangement of array

Problem Approach:
- how to determine "next" permutation?
    - goal is to make next-largest possible number
    - this is done by switching values in the array
    - the search starts from the end because switching vals in the 10s or 100s spot
      has far less effect on the overall value than switching vals in the >= 1000s spot
    - an existence of a value < a later value in the array represents a disorder
    - how do you find the smallest disorder to correct?
        - you find the val closest to the end that has a smaller number before it, or x
            - the smaller number has to be the closest smaller number to val, or y
        - you swap x and y
        - then, you have to make sure that everything after the swap is in ascending order
            - this is to ensure that the lex. value is being increased by the smallest amount

- how to determine if there is no "next" permutation, 
  aka supplied perm. is greatest perm.,
  aka supplied perm. is in descending order
  - if no "next" permutation is found during search
    - how to then find smallest perm.?
        * sort array in ascending order
            - return array

Problems With Approach:
- my approach turned out to be bad because it makes a bad swap; the swap doesn't incur the 
  minimal amount of lex. increase
- my approach uses nested for loops
    - the first checks one int at a time, n, starting from the end of the array and moving
      towards the beggining
    - the second does the same, but starts from the spot before n; this val is y
    - the swap is made if y > n
    - this approach doesn't take into account if a val after n and before y can be swapped
        - this swap is in the middle of the range
- example of my swap approach:
    - 0,2,3,2,0 (starting set)
    - 2,2,3,0,0 (after initial swap)
    - 2,0,0,2,3 (complete next permutation)

- this can be fixed by ensuring that the 2nd value being swapped, y, is closest to the
  end of the array, regardless of if n is the closest later value to the end of the array
- this is because the earlier spots in the array have more lex. value, and so they 
  should be treated with more weight
- example of correct swap approach:
    - 0,2,3,2,0 (starting set)
    - 0,3,2,2,0 (after initial swap)
    - 0,3,0,2,2 (complete next permutation)

How To Fix Problem:
- because earlier spot in array has more weight, the earlier spot should be moved in the
  outer loop, and everything after the earlier spot should be checked every time its moved
- this contrasts the first approach where the later spot was moved in the outer loop, and 
  everything before it was checked

Optimizations:
- brain hurty

Chicken Scratch:
    2,3,1 to 3,2,1
    - the least-impactful swap has been made, but that doesn't mean the least impactful
      combination has been found

    3,4,2,1
    4,3,2,1
    4,2,3,1
    4,1,3,2
    4,1,2,3

    after swap has been made, ensure everything after swap is in ascending order. 
    - do this by moving from spot after swap and swapping that with smaller value after it
    - ensure that every value after earlier swapped value has nothing smaller than itself
    later in the array
    - each spot needs to be checked, some spots need to be checked multiple times
        - wrap a while loop in a for loop
            - the while loop should stop when the end of the array is reached, and reset
              when a swap is made
*/
