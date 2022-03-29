using System;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTest;
using SimpleTest.Logger;

namespace IntegrationTest;

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
    public void TestAbcSort_ShouldReturnOrderedWords_WhenPassedAString()
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
    public void TestAbcSort_ShouldReturnCaseOrderedWords_WhenPassedAString()
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
    public void TestAbcSort_ShouldReturnRemoveInvalidChars_WhenPassedAString()
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
    public void TestAbcSort_ShouldReturnOrderedWords_WhenPassedASimpleTest1()
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
    public void TestAbcSort_ShouldReturnOrderedWords_WhenPassedASimpleTest2()
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
    public void TestAbcSort_ShouldCallTheLoggerTwiceWithTheCorrectMessages_WhenPassedASimpleTest()
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
    public void TestAbcSort_ShouldReturnArgumentNullException_WhenPassedAnEmptyString()
    {
        // Arrange
        var input = "";

        // Act
        var actual = _textAbcSort.Sort(input);

        // Assert - Expects exception
    }
}