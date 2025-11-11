using GitHubApp.Models;

namespace GitHubApp.Services
{
    public interface IGitHubService
    {
        //Task represents an asynchronous operation)
        Task<IEnumerable<GitRepo>> SearchRepositoriesAsync(string query);
    }
}
