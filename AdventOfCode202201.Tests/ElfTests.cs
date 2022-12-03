namespace AdventOfCode202201.Tests;

[UsesVerify]
public class ElfTests : VerifyBase
{
    public ElfTests() : base() { }

    [Fact]
    public async Task AnElf()
    {
        var elf = new Elf();
        elf.AddCalories(1000);
        await Verify(elf);
    }
}