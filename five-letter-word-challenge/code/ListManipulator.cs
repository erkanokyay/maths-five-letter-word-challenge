using System.Text.RegularExpressions;

namespace five_letter_word_challenge.code;

public class ListManipulator
{

    public List<string> GetLettersOnly(List<string> fiveLetterWords)
    {
        string pattern = @"^[A-Za-z]{5}$";
        Regex rg = new Regex(pattern);


        var x = fiveLetterWords.Where(f => rg.IsMatch(f)).ToList();

        return x;


    }
    
    public List<string> GetFiveFiveLetterWordsWithTwentyFiveUniqueLetters(List<string> fiveLetterWords)
    {
        List<char> usedLetters = new List<char>();

        List<string> fiveLetterWordsWithTwentyFiveUniqueLetters = new List<string>();

        foreach (var word in fiveLetterWords)
        {
            if (usedLetters.Count == 0)
            {
                fiveLetterWordsWithTwentyFiveUniqueLetters.Add(word);
                foreach (var character in word)
                {
                    usedLetters.Add(character);
                }
            }

            foreach (var letter in usedLetters)
            {
                if (word.Contains(letter))
                    break;

                if (letter == usedLetters[^1])
                {
                    fiveLetterWordsWithTwentyFiveUniqueLetters.Add(word);
                    foreach (var character in word)
                    {
                        usedLetters.Add(character);
                    }

                    break;
                }
               

            }
        }

        return fiveLetterWordsWithTwentyFiveUniqueLetters;
    }
}