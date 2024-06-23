public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> toReturn = new List<IList<int>>();
        for (int i = 0; i <= nums.Length - 3; i++)
        {
            for (int j = i + 1; j <= nums.Length - 2; j++)
            {
                for (int k = j + 1; k <= nums.Length - 1; k++)
                {
                    if (nums[i] + nums[j] + nums[k] == 0)
                    {
                        List<int> toAdd = new List<int> { nums[i], nums[j], nums[k] };
                        toAdd.Sort();
                        bool contains = false;
                        foreach (IList<int> list in toReturn)
                        {
                            if (
                                toAdd[0] == list[0] &&
                                toAdd[1] == list[1] &&
                                toAdd[2] == list[2]
                            )
                            {
                                contains = true;
                                break;
                            }
                        }
                        if (!(contains)) { toReturn.Add(toAdd); }
                    }
                }
            }
        }
        return toReturn;
    }
}

// problem pointers:
// - array isn't sorted
// - array contains >= 3 elements
// - no duplicate solution sets
// - vals in solution sets must not come from the same indices

// first thoughts (no optimizations):
// - every combo needs to be parsed, so three pointers should be maintained
// - no two pointers should ever point to the same index
// - double-nested loop should cover every combo
// - combos just need to be parsed forward

// edge cases
// - input contains three vals (either contains solution set or it doesn't)
// - input results in duplicate solution sets

// solving duplicate problem
// - enhance logic to avoid duplicates (seems impossible with current solution)
// - explicitly check if a duplicate set already exists

// this brute force solution doesn't work because it takes too long
// - to fix this, input should initially be sorted; this changes the problem completely