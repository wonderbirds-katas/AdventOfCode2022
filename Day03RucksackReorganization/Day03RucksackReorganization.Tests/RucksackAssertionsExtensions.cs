using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace Day03RucksackReorganization.Tests;

public static class RucksackAssertionsExtensions
{
    /// <summary>
    /// Expects both compartments of <paramref name="actual" /> to hold the same items as <paramref name="expected" />
    /// </summary>
    /// <remarks>
    /// <para>
    /// This extension method follows the scheme suggested in
    /// <a href="https://stackoverflow.com/questions/66358810/providing-an-extension-to-fluentassertions">StackOverflow:
    /// Providing an extension to FluentAssertions</a>.
    /// </para>
    /// <para>
    /// If you implement the <c>Should(this ... instance)</c> extension method as shown in
    /// <a href="https://fluentassertions.com/extensibility/#building-your-own-extensions">
    /// Fluent Assertions: Extensibility</a>, then the compiler will use <c>AssertionExtensions.Should(this object
    /// actualValue)</c> instead of your custom implementation. You would not be able to call your custom assertions,
    /// because <c>AssertionExtensions.Should(this object actualValue)</c> returns an instance of
    /// <c>ObjectAssertions</c>.
    /// </para>
    /// </remarks>
    /// <param name="actual">the Rucksack on which this assertion is executed</param>
    /// <param name="expected">the Rucksack to which we compare <paramref name="actual" /></param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    /// <returns></returns>
    public static AndConstraint<ObjectAssertions> BePackedLike(
        this ObjectAssertions actual,
        Rucksack expected,
        string because = "",
        params object[] becauseArgs
    )
    {
        var subject = (Rucksack)actual.Subject;

        AssertCompartmentItemsMatch(
            subject.FirstCompartment.Items,
            expected.FirstCompartment.Items,
            "first",
            because,
            becauseArgs
        );
        AssertCompartmentItemsMatch(
            subject.SecondCompartment.Items,
            expected.SecondCompartment.Items,
            "second",
            because,
            becauseArgs
        );

        return new AndConstraint<ObjectAssertions>(actual);
    }

    private static void AssertCompartmentItemsMatch(
        List<Item> actual,
        List<Item> expected,
        string ordinalNumberOfCompartment,
        string because,
        object[] becauseArgs
    )
    {
        var messageFormat =
            $"Expected {ordinalNumberOfCompartment} compartment of {{context:rucksack}} to contain {{0}}{{reason}}, but found {{1}}.";

        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => actual)
            .ForCondition(items => items.SequenceEqual(expected))
            .FailWith(messageFormat, _ => expected, items => items);
    }
}
