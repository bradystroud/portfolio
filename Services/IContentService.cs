using Microsoft.AspNetCore.Components;
using Markdig;
using Portfolio.Classes;

namespace Portfolio.Services;

public interface IContentService
{
    Task<string> GetHomePageContent();
    Task<string> GetBlog1();
    Task<string> GetBlog2();
    Task<IList<Blog>> GetBlogList();
}