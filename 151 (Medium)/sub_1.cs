Runtime: beats 34% @ 63 milliseconds
Memory: beats 5% @ 83 megabytes

public class Solution
{
    public string ReverseWords(string s)
    {
        int sIndex = 0;
        int l = s.Length;
        string toReturn = "";
        //Stack<string> words = new();
        while (sIndex != s.Length)
        {
            // enter word search mode
            while (sIndex != l && s[sIndex] == ' ')
            {
                sIndex++;
            }

            if(sIndex == l) { break; }

            // enter word processing mode
            string toInsert = "";
            while (sIndex != l && s[sIndex] != ' ')
            {
                toPush += s[sIndex];
                sIndex++;
            }

            toReturn.Insert(0, toInsert);
        }

        return toReturn;
    }
}

/**
Problem Info:
- General Instructions:
    - Given an input string s, reverse the order of the words in the string
    - Return the words in a String, concanenated by a single space
- Definitions:
    - A word is a sequence of characters not containing a space
- Input Info:
    - The words in the input String, s, are seperated by at-least one space, but can be seperated by more than one
        - the words don't form a traditional sentence, where they'd only be seperated by one space
    - s can have leading or trailing space/s
    - s has at-least one word
    - s has a length of at-least one
    - s contains digits and letters

Compare To Past Problems / Initial Prob. Info
- I know I'm supposed to use two pointers running from both ends of the array (supposedly)
- this is similar to a problem I did for an interview, but still quite different

Input Cases: 
- Edge Cases:
    - there is only one word
        - should be treated the same logically
    - there is only one letter (will make sure pointers don't go out-of-bounds here)
    - there are leading/trailing spaces 
        - should be treated the same logically
- Base Cases:
    - there are multiple words

Solution Thoughts
- the words have to be individually located in the sentence
    - the program logic has to somehow be aware of the start and end of every word
    - two ways to do this
        - the start of a word could be marked by the moving between a space and a letter
        - the start of a word could be marked by the existence of a letter at the start of the array / search space
- the words somehow have to be pulled from the sentence
    - perhaps substring could be used?
    - characters could also be individually concatenated to a string to avoid maintaining a pointer to the beginning of a discovered word
        - this seems preferable because having two pointers when its a possibility to have a word with one letter is unfortunate
        - this could potentially allow for only one pointer to be necessary...each letter could be parsed a single time
- the words have to be stored in reverse order 
    - I'm thinking a stack could be used...search starts from the front of s and whenever a word is fully parsed it gets thrown on the stack
    - the return sentence is then built using this stack
- so, there are three modes to the program
    - word search mode
    - word processing mode
    - return mode
- program logic:

    - search mode starts at index i
        - i starts at beginning of string, and is updated whenever word processing mode exits
    - search mode runs until two cases 
        - beginning of word is found, which is marked by the existence of a letter
            - enter word processing mode
        - end of string is reached
            - enter return mode / break while loop

    - word processing mode starts
        - word data is pushed onto str
    - word processing mode is exited in two situations
        - space is encountered
            - add str to stack
            - move search space up to index of space
            - continue while loop containing word search and word processing mode
        - end of string is reached
            - add str to stack
            - enter return mode / break while loop
       
    - return mode starts
        - string is constructed using stack of discovered words

    - problems with logic
        - how to tell when end of string is reached?
            - an impossible access is attempted
*/

