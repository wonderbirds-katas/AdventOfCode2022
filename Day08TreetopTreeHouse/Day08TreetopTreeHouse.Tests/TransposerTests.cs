namespace Day08TreetopTreeHouse.Tests;

public class TransposerTests
{
    [Fact]
    public void NoRows()
    {
        var actual = Transposer.Transpose(Array.Empty<string>());
        actual.Should().BeEmpty();
    }

    [Fact]
    public void NoColumns()
    {
        var actual = Transposer.Transpose(new []{ "" });
        actual.Should().BeEmpty();
    }
    
    [Fact]
    public void SingleElement()
    {
        var actual = Transposer.Transpose(new [] { "a" });
        AssertEquals(new[] { "a" }, actual);
    }

    [Fact]
    public void SingleRowWithTwoColumns()
    {
        var actual = Transposer.Transpose(new [] { "ab" });
        AssertEquals(new[] {"a", "b"}, actual);
    }

    [Fact]
    public void ThreeRowsWithFiveColumns()
    {
        var input = new []
        {
            "abcde",
            "12345",
            "vwxyz"
        };
        
        var actual = Transposer.Transpose(input);

        var expected = new[]
        {
            "a1v",
            "b2w",
            "c3x",
            "d4y",
            "e5z"
        };
        AssertEquals(expected, actual);
    }

    private static void AssertEquals(string[] expected, IEnumerable<IEnumerable<char>> actual)
    {
        var actualAsStringList = actual
            .Select(row => new string(row.ToArray()))
            .ToList();
        
        actualAsStringList.Should().ContainInConsecutiveOrder(expected);
        actualAsStringList.Should().HaveCount(expected.Length);
    }
}
