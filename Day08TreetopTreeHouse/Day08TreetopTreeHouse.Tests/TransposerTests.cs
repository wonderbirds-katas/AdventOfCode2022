namespace Day08TreetopTreeHouse.Tests;

public class TransposerTests
{
    [Fact]
    public void SingleElement()
    {
        var actual = Transposer.Transpose(new [] { "a" });
        actual.Should().ContainInOrder("a");
    }
}
