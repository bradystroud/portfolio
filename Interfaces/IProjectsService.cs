using Portfolio.Classes;

namespace Portfolio.Interfaces;

public interface IProjectsService
{
    Task<IList<Project>> GetPinnedProjects();
}