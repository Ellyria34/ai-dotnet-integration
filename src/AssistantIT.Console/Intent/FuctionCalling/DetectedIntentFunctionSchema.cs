internal static class DetectedIntentFunctionSchema
{
    public const string Json = """
    {
        "name": "detect_user_intent",
        "description": "Detect the user's intent for an IT support assistant",
        "parameters": {
        "type": "object",
        "properties": {
            "intent": {
            "type": "string",
            "enum": [
                "AnalyzeTicket",
                "AnalyzeLogs",
                "ClarifyRequest",
                "Unknown"
            ]
            },
            "reason": {
                "type": "string"
            }
        },
        "required": ["intent"]
        }
    }
    """;
}