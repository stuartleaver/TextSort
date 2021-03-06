namespace TextABCSort.UnitTests;

[TestClass]
public class TextAbcSortTests
{
    private ILogger _logger;

    private TextAbcSort _textAbcSort;

    [TestInitialize]
    public void Setup()
    {
        _logger = A.Fake<ILogger>();

        _textAbcSort = new TextAbcSort(_logger);
    }

    [TestMethod]
    public void TextAbcSort_ShouldReturnOrderedWords_WhenPassedAString()
    {
        // Arrange
        var input = "Zoom Boom";
        var expected = "Boom Zoom";

        // Act
        var actual = _textAbcSort.Sort(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TextAbcSort_ShouldReturnCaseOrderedWords_WhenPassedAString()
    {
        // Arrange
        var input = "boom Boom";
        var expected = "Boom boom";

        // Act
        var actual = _textAbcSort.Sort(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TextAbcSort_ShouldReturnRemoveInvalidChars_WhenPassedAString()
    {
        // Arrange
        var input = "b, b";
        var expected = "b b";

        // Act
        var actual = _textAbcSort.Sort(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TextAbcSort_ShouldReturnOrderedWords_WhenPassedASimpleTest1()
    {
        // Arrange
        var input = "Go baby, go";
        var expected = "baby Go go";

        // Act
        var actual = _textAbcSort.Sort(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TextAbcSort_ShouldReturnOrderedWords_WhenPassedASimpleTest2()
    {
        // Arrange
        var input = "CBA, abc aBc ABC cba CBA.";
        var expected = "ABC aBc abc CBA CBA cba";

        // Act
        var actual = _textAbcSort.Sort(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TextAbcSort_ShouldCallTheLoggerTwiceWithTheCorrectMessages_WhenPassedASimpleTest()
    {
        // Arrange
        var input = "Go baby, go";

        // Act
        var actual = _textAbcSort.Sort(input);

        // Assert
        A.CallTo(() => _logger.Log("Start sorting text alphabetically")).MustHaveHappenedOnceExactly();
        A.CallTo(() => _logger.Log("Finished sorting text alphabetically")).MustHaveHappenedOnceExactly();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TextAbcSort_ShouldReturnArgumentNullException_WhenPassedAnEmptyString()
    {
        // Arrange
        var input = "";

        // Act
        var actual = _textAbcSort.Sort(input);

        // Assert - Expects exception
    }
}