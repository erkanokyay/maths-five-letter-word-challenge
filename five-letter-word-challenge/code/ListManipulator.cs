using System.Text.RegularExpressions;

namespace five_letter_word_challenge.code;

public static class ListManipulator
{

    public static List<string> GetOnlyAlphabeticCharactersContainingWords(IEnumerable<string> wordList)
    {
        return wordList.Where(word => new Regex(@"^[a-zA-Z]{5}$").IsMatch(word)).ToList();
    }

    public static List<string> RemoveWordsContainingTheSameCharMultipleTimes(IEnumerable<string> wordList)
    {
        List<string> newWordList = new List<string>();
        foreach (var word in wordList)
        {
            if (word.Distinct().Count() == word.Length) newWordList.Add(word);
        }

        return newWordList;
    }

    public static List<string> TryUniqueWordCombinationsUntilThereAreFive(List<string> wordList)
    {
        List<string> uniqueWords = new List<string>();
        for (int i = 0; i < Int32.MaxValue; i++)
        {
            uniqueWords = GetFiveFiveLetterWordsWithTwentyFiveUniqueLetters(wordList);
            
            if (uniqueWords.Count >= 4) break;
            
            wordList = wordList.Except(uniqueWords).ToList();
            
        }

        return uniqueWords;
    }

    public static List<string> GetFiveFiveLetterWordsWithTwentyFiveUniqueLetters(List<string> wordList)
    {
        List<char> charsToUse = new List<char>(
            new char[]
            {
                'a', 'b', 'c', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
                'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            });
        List<char> usedLetters = new List<char>();

        List<string> newWordList = new List<string>();

        foreach (var word in wordList)
        {
            byte counter = 0;
            byte alphabetCounter = 0;
            List<char> charactersInWord = new List<char>();
            
            foreach (var character in charsToUse)
            {
                counter++;
                /*
                if (!word.Contains(character))
                {
                    counter = 0;
                    charactersInWord = new List<char>();
                    break;
                }
                */

                if (word.Contains(character))
                {
                    alphabetCounter++;
                    charactersInWord.Add(character);
                }

                if (alphabetCounter == 5)
                {
                    newWordList.Add(word);
                    charsToUse = charsToUse.Except(charactersInWord).ToList();

                    alphabetCounter = 0;
                    counter = 0;
                    charactersInWord = new List<char>();
                    break;

                }

                if (counter == charsToUse.Count)
                {
                    alphabetCounter = 0;
                    counter = 0;
                    charactersInWord = new List<char>();
                };
            }

        }

        return newWordList;

    }
}


/*
if (usedLetters.Count == 0)
{
    newWordList.Add(word);
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
        newWordList.Add(word);
        foreach (var character in word)
        {
            usedLetters.Add(character);
        }

        break;
    */
