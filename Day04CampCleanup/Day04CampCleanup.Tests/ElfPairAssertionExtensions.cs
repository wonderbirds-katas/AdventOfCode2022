using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace Day04CampCleanup.Tests;

public static class ElfPairAssertionExtensions
{
    public static AndConstraint<ObjectAssertions> ContainSections(this ObjectAssertions actual, int[] _firstElfSections,
        int[] _secondElfSections)
    {
        var subject = (ElfPair) actual.Subject;
        
        AssertSectionIdsMatch(_firstElfSections, subject.FirstElfSections, "first");
        AssertSectionIdsMatch(_secondElfSections, subject.SecondElfSections, "second");
        
        return new AndConstraint<ObjectAssertions>(actual);
    }

    private static void AssertSectionIdsMatch(int[] expected, int[] actual, string ordinal)
    {
        var messageFormat = $"Expected {ordinal} {{context:elf}} to be assigned to {{0}}, but found {{1}}.";
        Execute.Assertion
            .Given(() => actual)
            .ForCondition(ids => ids.SequenceEqual(expected))
            .FailWith(messageFormat,
                _ => expected, ids => ids);
    }
}