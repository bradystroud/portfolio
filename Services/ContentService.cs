using Microsoft.AspNetCore.Components;
using Markdig;

namespace Portfolio.Services;

public class ContentService : IContentService
{
    private readonly HttpClient _httpClient;

    public ContentService(HttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task<string> GetHomePageContent()
    {
        var text = await _httpClient.GetStringAsync($"/Content/home.md");
        return Markdown.ToHtml(text);
    }
}