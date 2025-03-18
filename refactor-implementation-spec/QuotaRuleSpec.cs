namespace Refactor.Implementation.Spec;

public class QuotaRuleSpec
{
    [Fact]
    public void WhenEvaluating_WithQuotaExceeded_ThenRuleIsNotSatisfied()
    {
        var foo = new Foo(11, 15);
        var rule = new QuotaRule(foo, 10);

        var result = rule.Evaluate();

        result.Should().BeFalse();
    }

    [Fact]
    public void WhenEvaluating_WithQuotaNotMet_ThenRuleIsSatisfied()
    {
        var foo = new Foo(1, 5);
        var rule = new QuotaRule(foo, 10);

        var result = rule.Evaluate();

        result.Should().BeTrue();
    }
}