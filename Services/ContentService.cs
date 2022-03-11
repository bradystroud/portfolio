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

    public async Task<string> GetBlog1()
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetBlog2()
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Blog>> GetBlogList()
    {
        var blogList = new List<Blog>();
        foreach (var file in Directory.EnumerateFiles("./Content/Blogs/", "*.md"))
        {
            var contents = await _httpClient.GetStringAsync("./Content/Blogs/");
            // Parse frontmatter 
            // Build Blog object
            blogList.Add(new Blog
            {
                Title = "",
                Content = contents
            });
        }

        return blogList;
    }
}