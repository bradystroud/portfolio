using System.Text.Json;
using Portfolio.Interfaces;
using Project = Portfolio.Classes.Project;

namespace Portfolio.Services;

public class ProjectsService : IProjectsService
{
    public async Task<IList<Project>> GetPinnedProjects()
    {
        var client = new HttpClient();
        
        var thing = client.GetStreamAsync("https://api.bradystroud.dev/repos.json");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            
        };
        var content = await JsonSerializer.DeserializeAsync<List<Project>>(await thing, options);

        return content;
    }
}