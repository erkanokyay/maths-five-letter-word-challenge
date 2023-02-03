using five_letter_word_challenge.code;

var fiveLetterWordsList =  FileReader.ReadOnlyFiveLetterWordsFromFile();

fiveLetterWordsList = ListManipulator.GetOnlyAlphabeticCharactersContainingWords(fiveLetterWordsList);

fiveLetterWordsList = ListManipulator.RemoveWordsContainingTheSameCharMultipleTimes(fiveLetterWordsList);

fiveLetterWordsList = ListManipulator.TryUniqueWordCombinationsUntilThereAreFive(fiveLetterWordsList);

foreach (var word in fiveLetterWordsList)
{
    Console.WriteLine(word);
}

Console.ReadKey();