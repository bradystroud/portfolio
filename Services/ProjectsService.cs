using Portfolio.Classes;
using Portfolio.Interfaces;

namespace Portfolio.Services;

public class ProjectsService : IProjectsService
{
    // private readonly HttpClient _client;

    // public ProjectsService(IHttpClientFactory clientFactory)
    // {
    //     // _client = clientFactory.CreateClient("Data");
    // }

    public async Task<IList<Project>> GetPinnedProjects()
    {
        // _client.BaseAddress = new Uri("https://api.coindesk.com/v1/bpi/currentprice.json");
        // _client.DefaultRequestHeaders.
        // var response = await _client.GetAsync("https://api.coindesk.com/v1/bpi/currentprice.json");
        // Console.WriteLine(response.StatusCode);

        return new List<Project>();
    }
}