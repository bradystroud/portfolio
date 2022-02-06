using Microsoft.AspNetCore.Components;
using Markdig;

namespace Portfolio.Services;

public interface IContentService
{
    Task<string> GetHomePageContent();
}