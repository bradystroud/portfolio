using Portfolio.Classes;

namespace Portfolio.Services;

public interface IContentService
{
    Task<string> GetHomePageContent();
    Task<Blog> GetBlog(MarkdownContent contentType);
    Task<IList<BlogFrontmatter>> GetBlogList();
    string GetPathForEnum(MarkdownContent contentType);
}