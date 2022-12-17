using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace Day03RucksackReorganization.Tests;

public static class RucksackAssertionsExtensions
{
    /// <summary>
    /// Expects both compartments of <paramref name="parent" /> to hold the same items as <paramref name="other" />
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
    /// <param name="parent">the Rucksack on which this assertion is executed</param>
    /// <param name="other">the Rucksack to which we compare <paramref name="parent" /></param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    /// <returns></returns>
    public static AndConstraint<ObjectAssertions> BeEqual(this ObjectAssertions parent,
        Rucksack other, string because = "", params object[] becauseArgs)
    {
        var subject = (Rucksack) parent.Subject;
        
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => subject.FirstCompartment.Items)
            .ForCondition(items => items.SequenceEqual(other.FirstCompartment.Items))
            .FailWith("Expected first compartment of {context:rucksack} to contain {0}{reason}, but found {1}.",
                _ => other.FirstCompartment.Items, items => items);
        
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => subject.SecondCompartment.Items)
            .ForCondition(items => items.SequenceEqual(other.SecondCompartment.Items))
            .FailWith("Expected second compartment of {context:rucksack} to contain {0}{reason}, but found {1}.",
                _ => other.SecondCompartment.Items, items => items);
        
        return new AndConstraint<ObjectAssertions>(parent);
    }
}