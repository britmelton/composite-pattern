namespace ReportManager.Domain.Reporting;

public class MatchRule : Rule
{
    private MatchRule(string targetQuestion, IEnumerable<string> targetValues)
    {
        TargetQuestion = targetQuestion;
        TargetValues = targetValues;
    }

    public string TargetQuestion { get; }
    public IEnumerable<string> TargetValues { get; }

    public override INode<Rule> Add(MatchRuleArgs args) =>
        Parent
            .Prune(this)
            .Add(
                new AllRule(
                    args.ReplacementValue,
                    this,
                    new MatchRule(
                        args.TargetQuestionId,
                        args.TargetValues
                    )
                )
            );

    public override bool Apply(QuestionResponse response, Survey survey, out string? adjustedResponse)
    {
        adjustedResponse = null;
        return TargetValues.Contains(survey[TargetQuestion].Response);
    }

    public static implicit operator MatchRule(MatchRuleArgs source) =>
        new(
            source.TargetQuestionId,
            source.TargetValues
        );
}
