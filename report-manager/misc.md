HasMatchingValues(IEnumerable<string> values, string variableName, IDictionary<string, string> questionResponses)
if questionsResponses contains key variableName

var questionResponse = questionResponses.ContainsKey(variableName) ? questionResponses[variableName] : null;
values.Any(valueToMatch => ValuesMatch(questionResponse, valueToMatch));