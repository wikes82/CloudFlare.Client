using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Pages;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones;

namespace CloudFlare.Client.Client.Pages;

/// <summary>
/// Interface for interacting with cloudflare pages
/// </summary>
public interface IPages
{
    /// <summary>
    /// Create new Pages Project
    /// </summary>
    /// <param name="newPagesProject">New Project </param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Newly created project</returns>
    Task<CloudFlareResult<PagesProject>> AddProjectAsync(NewPagesProject newPagesProject, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve List of CF Pages
    /// </summary>
    /// <param name="accountId">Account ID</param>
    /// <param name="displayOptions">Display options</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>List of CF Pages</returns>
    Task<CloudFlareResult<IReadOnlyList<PagesProject>>> GetProjectAsync(string accountId, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get details of CF pages project
    /// </summary>
    /// <param name="accountId">Account ID</param>
    /// <param name="projectName">Project Name</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Details</returns>
    Task<CloudFlareResult<PagesProject>> GetProjectDetailsAsync(string accountId, string projectName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Domains for CF Pages Project
    /// </summary>
    /// <param name="accountId">Account ID</param>
    /// <param name="projectName">Project Name</param>
    /// <param name="displayOptions">Display Options</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>PagesDomain info</returns>
    Task<CloudFlareResult<IReadOnlyList<PagesDomain>>> GetDomainsForProjectAsync(string accountId, string projectName, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);
}
