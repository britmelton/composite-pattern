namespace ReportManager.Domain.Reporting;

/// <summary>
///     Represents a set of logic applied to <see cref="Survey" /> responses when building a <see cref="Report" />.
/// </summary>
/// <remarks>The component class in the composite design pattern.</remarks>
public abstract partial class Rule
{
    /// <summary>
    ///     Applies the <see cref="Rule" /> to the supplied <see cref="QuestionResponse" />.
    /// </summary>
    /// <param name="response">The <see cref="Survey" /> response that is being mapped to a <see cref="Report" /> response.</param>
    /// <param name="survey">The survey the response came from. Used to look up other response values if necessary.</param>
    /// <param name="adjustedResponse">The adjusted response value if an adjustment was warranted.</param>
    /// <returns>
    ///     <c>true</c> if a rule was satisfied, <c>false</c> otherwise. <c>true</c> does not guarantee an adjusted
    ///     response.
    /// </returns>
    public abstract bool Apply(
        QuestionResponse response,
        Survey survey,
        out string? adjustedResponse
    );
}
