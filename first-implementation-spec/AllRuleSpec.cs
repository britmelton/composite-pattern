namespace First.Implementation.Spec;

public class AllRuleSpec
{
    [Fact]
    public void WhenEvaluating_WithTwoUnsatisfiedRules_ThenRuleIsNotSatisfied()
    {
        var rule = new AllRule();

        rule.Add(new EvenRule());
        rule.Add(new QuotaRule(10));

        var result = rule.Evaluate(15);

        result.Should().BeFalse();
    }

    [Fact]
    public void WhenEvaluating_WithOneUnsatisfiedRule_ThenRuleIsNotSatisfied()
    {
        var rule = new AllRule();

        rule.Add(new EvenRule());
        rule.Add(new QuotaRule(10));

        var result = rule.Evaluate(14);

        result.Should().BeFalse();
    }

    [Fact]
    public void WhenEvaluating_WithTwoSatisfiedRules_ThenRuleIsSatisfied()
    {
        var rule = new AllRule();

        rule.Add(new EvenRule());
        rule.Add(new QuotaRule(10));

        var result = rule.Evaluate(4);

        result.Should().BeTrue();
    }

}
