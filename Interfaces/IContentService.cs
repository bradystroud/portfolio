using Portfolio.Classes;

namespace Portfolio.Interfaces;

public interface IContentService
{
    Task<string> GetHomePageContent();
    Task<string> GetBlog1();
    Task<string> GetBlog2();
    Task<IList<Blog>> GetBlogList();
}