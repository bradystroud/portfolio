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

    public IList<Project> Projects { get; set; } = new List<Project>();
    private static string BlogUrlBase => "/blogs/";

    protected override async Task OnInitializedAsync()
    {
        Projects = await ProjectsService.GetPinnedProjects();
    }
}