using Microsoft.AspNetCore.Components;
using Portfolio.Classes;
using Portfolio.Interfaces;

namespace Portfolio.Pages;

public partial class Index
{
    [Inject]
    public HttpClient Http { get; set; }

    [Inject]
    public IProjectsService ProjectsService { get; set; }

    public IList<Project> Projects { get; set; }
    private static string BlogUrlBase => "https://medium.com/@bradystroud";

    protected override async Task OnInitializedAsync()
    {
        await Http.GetAsync("https://api.coindesk.com/v1/bpi/currentprice.json");
        await GetGitHubPins();
    }

    private async Task GetGitHubPins()
    {
        Projects = await ProjectsService.GetPinnedProjects();
    }
}