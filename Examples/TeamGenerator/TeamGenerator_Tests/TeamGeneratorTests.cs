using TeamGenerator.Models;

namespace TeamGenerator_Tests;

public class TeamGeneratorTests
{
    [SetUp]
    public void Setup()
    {
    }

    //public List<string> SplitStringByNewline(string str)

    [Test]
    public void TestGenerator_EmptyStringOfNames_ReturnsEmptyList()
    {
        // Arrange
        var names = "";
        var expected = new List<string>();
        // Act
        var actual = Teams.SplitStringByNewline(names);
        // Assert
        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void TestGenerator_NullNameString_ReturnsEmptyList()
    {
        // Arrange
        string names = null;
        var expected = new List<string>();
        // Act
        var actual = Teams.SplitStringByNewline(names);
        // Assert
        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void TestGenerator_SingleName_ReturnsListWithOneName()
    {
        // Arrange
        var names = "John";
        var expected = new List<string>() { "John" };
        // Act
        var actual = Teams.SplitStringByNewline(names);
        // Assert
        Assert.That(expected, Is.EqualTo(actual));
    }
}