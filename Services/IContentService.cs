using Microsoft.AspNetCore.Components;
using Markdig;
using Portfolio.Classes;

namespace Portfolio.Services;

public interface IContentService
{
    Task<string> GetHomePageContent();
    Task<Blog> GetBlog(BlogFrontMatter uri);
    Task<IList<BlogFrontMatter>> GetBlogList();
}