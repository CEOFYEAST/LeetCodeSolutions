Runtime: Beats 54 % of submissions @ 63 milliseconds
Memory: Beats 60% of submissions @ 49 megabytes

public class Solution
{
    public string ReverseWords(string s)
    {
        string[] words = s.Split();
        for (int i = 0; i < words.Length; i++)
        {
            char[] word = words[i].ToCharArray();
            Array.Reverse(word);
            words[i] = String.Join(
                null,
                word
            );
        }
        return String.Join(' ', words);
    }
}