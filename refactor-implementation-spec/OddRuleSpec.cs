namespace Refactor.Implementation.Spec;

public class OddRuleSpec
{
    [Fact]
    public void WhenCheckingIfNumberIsOdd_WithOddNumber_ThenRuleIsSatisfied()
    {
        var foo = new Foo(1, 3, 5);
        var rule = new OddRule(foo);

        var result = rule.Evaluate();

        result.Should().BeTrue();
    }

    [Fact]
    public void WhenCheckingIfNumberIsOdd_WithEvenNumber_ThenRuleIsNotSatisfied()
    {
        var foo = new Foo(2, 4, 6);
        var rule = new OddRule(foo);

        var result = rule.Evaluate();

        result.Should().BeFalse();
    }
}
