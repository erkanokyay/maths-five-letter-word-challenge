namespace five_letter_word_challenge.code;

public class FileReader
{
    public  List<string> ReadOnlyFiveLetterWordsFromFile()
    {
        List<string> fiveLetterWords = new List<string>();
        try
        {
            foreach (string line in System.IO.File.ReadLines("../../../src/words.txt"))
            {
                if(line.Length == 5) fiveLetterWords.Add(line);
            }  
           
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        return fiveLetterWords;
    }
}