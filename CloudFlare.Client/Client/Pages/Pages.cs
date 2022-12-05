using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Pages;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Helpers;

namespace CloudFlare.Client.Client.Pages;

/// <summary>
/// API methods to interact with Cloudflare Pages
/// </summary>
public class Pages : ApiContextBase<IConnection>, IPages
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Pages"/> class.
    /// </summary>
    /// <param name="connection">Connection settings</param>
    public Pages(IConnection connection)
        : base(connection)
    {
    }

    /// <summary>
    /// add new pages project
    /// </summary>
    /// <param name="newPagesProject">new pages project info</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>newly created pages project</returns>
    public async Task<CloudFlareResult<PagesProject>> AddProjectAsync(NewPagesProject newPagesProject, CancellationToken cancellationToken = default)
    {
        var accountId = newPagesProject.Account.Id;
        var requestUri = $"{AccountEndpoints.Base}/{accountId}/{PagesEndpoints.Base}/{PagesEndpoints.Projects}";
        return await Connection.PostAsync<PagesProject, NewPagesProject>(requestUri, newPagesProject, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc cref="IPages" />
    public async Task<CloudFlareResult<IReadOnlyList<PagesProject>>> GetProjectAsync(string accountId, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
    {
        var builder = new ParameterBuilderHelper()
            .InsertValue(Filtering.Page, displayOptions?.Page)
            .InsertValue(Filtering.PerPage, displayOptions?.PerPage);
        var requestUri = $"{AccountEndpoints.Base}/{accountId}/{PagesEndpoints.Base}/{PagesEndpoints.Projects}";

        if (builder.ParameterCollection.HasKeys())
        {
            requestUri = $"{requestUri}/?{builder.ParameterCollection}";
        }

        return await Connection.GetAsync<IReadOnlyList<PagesProject>>(requestUri, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get details of CF pages project
    /// </summary>
    /// <param name="accountId">Account ID</param>
    /// <param name="projectName">Project Name</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Details</returns>
    public async Task<CloudFlareResult<PagesProject>> GetProjectDetailsAsync(string accountId, string projectName, CancellationToken cancellationToken = default)
    {
        var requestUri =
            $"{AccountEndpoints.Base}/{accountId}/{PagesEndpoints.Base}/{PagesEndpoints.Projects}/{projectName}";
        return await Connection.GetAsync<PagesProject>(requestUri, cancellationToken);
    }

    /// <summary>
    /// Get Domains for CF Pages Project
    /// </summary>
    /// <param name="accountId">Account ID</param>
    /// <param name="projectName">Project Name</param>
    /// <param name="displayOptions">Display options</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>PagesDomain info</returns>
    public async Task<CloudFlareResult<IReadOnlyList<PagesDomain>>> GetDomainsForProjectAsync(string accountId, string projectName, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
    {
        var builder = new ParameterBuilderHelper()
            .InsertValue(Filtering.Page, displayOptions?.Page)
            .InsertValue(Filtering.PerPage, displayOptions?.PerPage);
        var requestUri = $"{AccountEndpoints.Base}/{accountId}/{PagesEndpoints.Base}/{PagesEndpoints.Projects}/{projectName}/{PagesEndpoints.Domains}";
        if (builder.ParameterCollection.HasKeys())
        {
            requestUri = $"{requestUri}/?{builder.ParameterCollection}";
        }

        return await Connection.GetAsync<IReadOnlyList<PagesDomain>>(requestUri, cancellationToken);
    }
}
