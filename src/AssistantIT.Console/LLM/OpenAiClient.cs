using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AssistantIT.Console.LLM;

/// <summary>
/// Real implementation of ILLMClient using OpenAI Chat Completions API.
/// This class is responsible ONLY for making the HTTP call.
/// No business logic, no parsing, no decision-making here.
/// </summary>
public class OpenAiClient : ILLMClient
{
    // HttpClient is injected to allow reuse, testing, and proper lifetime management
    private readonly HttpClient _httpClient;  
        
    // OpenAI API key, read from environment variables
    private readonly string _apiKey;

    public OpenAiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;

        // Read the API key from environment variables
        // Fail fast if it is not configured
        _apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
            ?? throw new InvalidOperationException("OPENAI_API_KEY is not set.");
    }

    /// <summary>
    /// Calls OpenAI Chat Completions API with function calling enabled.
    /// Returns the raw JSON response as a string.
    /// </summary>
    public async Task<string> CallAsync(
        string systemPrompt,
        string userMessage,
        string functionSchemaJson)
    {
        // Build the request body expected by OpenAI
        // - model: which LLM to use
        // - messages: system + user messages
        // - functions: function calling schema (parsed from JSON string)
        // - function_call: let the model decide when to call the function
        var requestBody = new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
                new { role = "system", content = systemPrompt },
                new { role = "user", content = userMessage }
            },
            functions = new[]
            {
                JsonSerializer.Deserialize<JsonElement>(functionSchemaJson)
            },
            function_call = "auto"
        };

        // Serialize the request body to JSON
        var json = JsonSerializer.Serialize(requestBody);

        using var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://api.openai.com/v1/chat/completions");

        // Add Authorization header: Bearer <API_KEY>
        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", _apiKey);

        // Attach JSON payload
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        // Send the HTTP request
        using var response = await _httpClient.SendAsync(request);

        // Throw an exception if the HTTP response is not successful (4xx / 5xx)
        response.EnsureSuccessStatusCode();

        // Return the raw JSON response body
        return await response.Content.ReadAsStringAsync();
    }
}
