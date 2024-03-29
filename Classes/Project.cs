using System.Text.Json.Serialization;

namespace Portfolio.Classes;

public class Project
{
    public string Name { get; set; } = string.Empty;

    public int Stars { get; set; }

    [JsonPropertyName("topics")]
    public IList<string> TechTags { get; set; } = new List<string>();

    public string Description { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;
}