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
            throw new ArgumentNullException("Input string is either null or empty");
        }

        _logger.Log("Start sorting text alphabetically");

        var result = RemoveUnwantedCharacters(input);

        var words = SortWordsAlphabetically(result);

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

        result = string.Join(" ", words);

        _logger.Log("Finished sorting text alphabetically");

        return result;
    }

    private static string RemoveUnwantedCharacters(string result)
    {
        // The characters to remove are currently included below making changes more difficult. So an improvement
        // would be to make then configurable
        string[] charactersToRemove = { "(", ".", ",", ";", "'", ")" };

        foreach (var character in charactersToRemove)
        {
            result = result.Replace(character, string.Empty);
        }

        return result;
    }

    private static IEnumerable<string> SortWordsAlphabetically(string result)
    {
        var sortedWords = result.Split(" ").OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
            .ThenBy(y => y, StringComparer.Ordinal);

        return sortedWords;
    }
}