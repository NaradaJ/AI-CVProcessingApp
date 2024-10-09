using Microsoft.Extensions.Configuration;
using OpenAI_API;
using OpenAI_API.Completions;

public class OpenAIService
{
    private readonly OpenAIAPI _api;

    public OpenAIService(IConfiguration configuration)
    {
        var apiKey = configuration["OpenAI:ApiKey"];
        _api = new OpenAIAPI(apiKey);
    }

    public async Task<string> GetCompletion(string prompt)
    {
        var request = new CompletionRequest
        {
            Prompt = prompt,
            MaxTokens = 100,
            Temperature = 0.7,
        };

        var completion = await _api.Completions.CreateAsync(request);
        return completion.Completions[0].Text.Trim();
    }
}
