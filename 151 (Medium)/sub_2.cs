Runtime: Beats 68.5% 
Memory: Beats 15%

public class Solution
{
    public string ReverseWords(string s)
    {
        bool inWord = false;
        string toInsert = String.Empty;
        string toReturn = String.Empty;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ')
            {
                toInsert += s[i];
                if (!(inWord)) { inWord = true; }
            }
            if ((s[i] == ' ' || i == s.Length - 1) && inWord)
            {
                toReturn = toReturn.Insert(0, toInsert + ' ');
                toInsert = String.Empty;
                inWord = false;
            }
        }
        return toReturn.Trim();
    }
}

/**
How to create a solution that:
- doesn't use any outside methods
- accesses every character in the string at most once
- doesn't have any nested loops
- doesn't use any complex objects
*/