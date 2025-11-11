using GitHubApp.Models;

namespace GitHubApp.Services
{
    public class GitHubService : IGitHubService
    {
        public Task<IEnumerable<GitRepo>> SearchRepositoriesAsync(string query)
        {
            return null;
        }
        readonly HttpClient _httpClient;
        readonly ILogger<GitHubService> _logger;

        public GitHubService(HttpClient httpClient, ILogger<GitHubService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

    }
}
