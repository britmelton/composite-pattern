namespace First.Implementation.Spec;

public class QuotaRuleSpec
{
    [Theory]
    [InlineData(10, 11)]
    [InlineData(10, 15)]
    public void WhenEvaluating_WithQuotaExceeded_ThenRuleIsNotSatisfied(decimal quota, decimal x)
    {
        var rule = new QuotaRule(quota);

        var result = rule.Evaluate(x);

        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(10, 1)]
    [InlineData(10, 5)]
    public void WhenEvaluating_WithQuotaNotMet_ThenRuleIsSatisfied(decimal quota, decimal x)
    {
        var rule = new QuotaRule(quota);

        var result = rule.Evaluate(x);

        result.Should().BeTrue();
    }
}