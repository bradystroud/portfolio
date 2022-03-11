using Microsoft.AspNetCore.Components;
using Markdig;
using Portfolio.Classes;

namespace Portfolio.Services;

public interface IContentService
{
    Task<string> GetHomePageContent();
    Task<IList<Blog>> GetBlogList();
}