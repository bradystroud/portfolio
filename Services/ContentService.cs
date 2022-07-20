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
        var text = await _httpClient.GetStringAsync($"./Content/home.md");
        return Markdown.ToHtml(text);
    }

    public async Task<Blog> GetBlog(MarkdownContent contentType)
    {
        var path = GetPathForEnum(contentType);
        var text = await _httpClient.GetStringAsync(path);

        var frontmatter = text.GetFrontMatter<BlogFrontmatter>();
        var content = text.GetMarkdownBody(); //TODO: remove frontmatter from content
        var renderedContent = Markdown.ToHtml(content);

        return new Blog
        {
            Content = renderedContent, 
            Frontmatter = frontmatter
        };
    }

    public async Task<IList<BlogFrontmatter>> GetBlogList()
    {
        var contentLocations = Enum.GetValues(typeof(MarkdownContent)).Cast<MarkdownContent>();

        var blogFrontmatters = new List<BlogFrontmatter>();

        foreach (var type in contentLocations)
        {
            var path = GetPathForEnum(type);
            string text;
            try
            {
                text = await _httpClient.GetStringAsync(path);
                var frontmatter = text.GetFrontMatter<BlogFrontmatter>();
                frontmatter.Uri = "blogs/" + path.Split('/').Last().Split('.').First();
                blogFrontmatters.Add(frontmatter);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        return blogFrontmatters;
    }

    public string GetPathForEnum(MarkdownContent contentType)
        => contentType switch
        {
            MarkdownContent.HomePage => "./Content/home.md",
            MarkdownContent.MauiBlazorBlog => "/Content/Blogs/maui-blazor.md",
            _ => ""
        };
}