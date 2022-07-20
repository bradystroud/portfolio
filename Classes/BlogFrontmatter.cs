using YamlDotNet.Serialization;

namespace Portfolio.Classes;

public class BlogFrontmatter
{
    public string Uri { get; set; }

    [YamlMember(Alias = "title")]
    public string Title { get; set; }

    [YamlMember(Alias = "date")]
    public DateTime Date { get; set; }
}