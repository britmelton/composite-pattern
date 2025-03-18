namespace Refactor.Implementation.Spec;

public class EvenRuleSpec
{
    [Fact]
    public void WhenCheckingIfNumberIsEven_WithEvenNumber_ThenRuleIsSatisfied()
    {
        var foo = new Foo(2, 4, 6);
        var rule = new EvenRule(foo);

        var result = rule.Evaluate();

        result.Should().BeTrue();
    }

    [Fact]
    public void WhenCheckingIfNumberIsEven_WithOddNumber_ThenRuleIsNotSatisfied()
    {
        var foo = new Foo(1, 3, 5);
        var rule = new EvenRule(foo);

        var result = rule.Evaluate();

        result.Should().BeFalse();
    }
}
