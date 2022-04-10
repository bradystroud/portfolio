using Markdig;
using Portfolio.Classes;

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

    public async Task<Blog> GetBlog(BlogFrontMatter frontMatter)
    {
        var text = await _httpClient.GetStringAsync($"./Content/Blogs/{frontMatter.Uri}");
        
        return new Blog
        {
            Content = text,
            FrontMatter = frontMatter
        };
    }

    public async Task<IList<BlogFrontMatter>> GetBlogList()
    {
        var blogList = new List<Blog>();
        
        var directory = Directory
            .GetFiles("./Content/Blogs/", "*.md");

        var posts = directory
            .Select(File.ReadAllText)
            .Select(md => md.GetFrontMatter<BlogFrontMatter>())
            .ToList();


        return posts;
    }
}