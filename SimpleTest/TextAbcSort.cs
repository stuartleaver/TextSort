using SimpleTest.Logger;

namespace SimpleTest;

public class TextAbcSort
{
    private readonly ILogger _logger;

    public TextAbcSort(ILogger logger)
    {
        _logger = logger;
    }

    public string Sort(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new DataMisalignedException("data not correct");
        }

        _logger.Log("Start text sorting");

        var result = input;

        result = RemoveUnwantedCharacters(result);

        // Split and order the input string into a list
        var words = result.Split(" ").OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ThenBy(y => y, StringComparer.Ordinal);

        // Not removing the following code as it was the initial implementation

        // Order words by case
        //var sortedWordsByCase = new List<string>();

        //var distinctWords = words.Distinct(StringComparer.OrdinalIgnoreCase);

        //foreach (var word in distinctWords)
        //{
        //    var wordGroup = words.Where(x => string.Equals(x, word, StringComparison.OrdinalIgnoreCase));

        //    var sortedWordGroup = wordGroup.OrderBy(y => y, StringComparer.Ordinal);

        //    sortedWordsByCase.AddRange(sortedWordGroup);

        //    words.RemoveAll(x => wordGroup.Contains(x));
        //}

        // Create the result by joining the words
        result = string.Join(" ", words);

        _logger.Log("End text sorting");

        return result;
    }

    private static string RemoveUnwantedCharacters(string result)
    {
        string[] charactersToRemove = { "(", ".", ",", ";", "'", ")" };

        foreach (var character in charactersToRemove)
        {
            result = result.Replace(character, string.Empty);
        }

        return result;
    }
}