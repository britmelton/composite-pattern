namespace First.Implementation.Spec;

public class EvenRuleSpec
{
    [Theory]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(6)]
    public void WhenCheckingIfNumberIsEven_WithEvenNumber_ThenRuleIsSatisfied(decimal x)
    {
        var rule = new EvenRule();

        var result = rule.Evaluate(x);

        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    public void WhenCheckingIfNumberIsEven_WithOddNumber_ThenRuleIsNotSatisfied(decimal x)
    {
        var rule = new EvenRule();

        var result = rule.Evaluate(x);

        result.Should().BeFalse();
    }
}
