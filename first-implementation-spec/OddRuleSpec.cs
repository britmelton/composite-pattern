namespace First.Implementation.Spec;

public class OddRuleSpec
{
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    public void WhenCheckingIfNumberIsOdd_WithOddNumber_ThenRuleIsSatisfied(decimal x)
    {
        var rule = new OddRule();

        var result = rule.Evaluate(x);

        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(6)]
    public void WhenCheckingIfNumberIsOdd_WithEvenNumber_ThenRuleIsNotSatisfied(decimal x)
    {
        var rule = new OddRule();

        var result = rule.Evaluate(x);

        result.Should().BeFalse();
    }
}
