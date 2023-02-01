using five_letter_word_challenge.code;

var fileReader = new FileReader();

var x =  fileReader.ReadOnlyFiveLetterWordsFromFile();

var listManipulator = new ListManipulator();

var cleanedUpWords = listManipulator.GetLettersOnly(x);

var theWords = listManipulator.GetFiveFiveLetterWordsWithTwentyFiveUniqueLetters(cleanedUpWords);

foreach (var word in theWords)
{
    Console.WriteLine(word);
}