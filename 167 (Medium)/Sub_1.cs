public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int[] toReturn = [1, 2];
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            //if(numbers[i] <= target){ // possibility of solution
            for (int j = 0; j < i; j++)
            { // finding solution
                if (numbers[j] + numbers[i] == target)
                { // solution found
                    toReturn = [j + 1, i + 1];
                }
            }
            //}
            // no solution found, or no solution possible
        }
        return toReturn;
    }
}

// edge cases missed:
// - adding zero and another number
// - adding number larger than target with a negative number

// optimizations:
// - take advantage of the sorted nature of the problem by moving the right pointer if the sum is greater than target (effectively decreasing all possible sums); left pointer is moved if sum is less than target
// - the above optimization drastically decreases the number of times the pointers have to be moved