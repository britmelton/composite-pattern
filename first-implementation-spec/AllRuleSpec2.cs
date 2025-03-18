namespace First.Implementation.Spec;

public class AllRuleSpec2
{
    [Fact]
    public void WhenEvaluating_WithTwoUnsatisfiedRules_ThenRuleIsNotSatisfied()
    {
        var rule = new AllRule2(
            new EvenRule(),
            new QuotaRule(10)
            );
        var result = rule.Evaluate(15);

        result.Should().BeFalse();
    }

    [Fact]
    public void WhenEvaluating_WithOneUnsatisfiedRule_ThenRuleIsNotSatisfied()
    {
        var rule = new AllRule2(
            new EvenRule(),
            new QuotaRule(10)
            );

        var result = rule.Evaluate(14);

        result.Should().BeFalse();
    }

    [Fact]
    public void WhenEvaluating_WithTwoSatisfiedRules_ThenRuleIsSatisfied()
    {
        var rule = new AllRule2(
            new EvenRule(),
            new QuotaRule(10)
            );

        var result = rule.Evaluate(4);

        result.Should().BeTrue();
    }
}
