namespace Refactor.Implementation.Spec;

public class AllRuleSpec
{
    [Fact]
    public void WhenEvaluating_WithTwoUnsatisfiedRules_ThenRuleIsNotSatisfied()
    {
        var foo = new Foo(11, 12, 15);
        var rule = new AllRule(foo);

        rule.Add(new EvenRule(foo));
        rule.Add(new QuotaRule(foo, 10));

        var result = rule.Evaluate();

        result.Should().BeFalse();
    }

    [Fact]
    public void WhenEvaluating_WithOneUnsatisfiedRule_ThenRuleIsNotSatisfied()
    {
        var foo = new Foo(8, 14);
        var rule = new AllRule(foo);

        rule.Add(new EvenRule(foo));
        rule.Add(new QuotaRule(foo, 10));

        var result = rule.Evaluate();

        result.Should().BeFalse();
    }

    [Fact]
    public void WhenEvaluating_WithTwoSatisfiedRules_ThenRuleIsSatisfied()
    {
        var foo = new Foo(2, 4, 6);
        var rule = new AllRule(foo);

        rule.Add(new EvenRule(foo));
        rule.Add(new QuotaRule(foo, 10));

        var result = rule.Evaluate();

        result.Should().BeTrue();
    }
}