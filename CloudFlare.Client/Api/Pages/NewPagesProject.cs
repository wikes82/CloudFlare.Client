using CloudFlare.Client.Api.Accounts;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Pages;

/// <summary>
/// New pages project
/// </summary>
public class NewPagesProject
{
    /// <summary>
    /// Account
    /// </summary>
    public Account Account { get; set; }

    /// <summary>
    /// The cf page project name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// production branch of the project. Used to identify production deployments
    /// </summary>
    [JsonProperty("production_branch")]
    public string ProductionBranch { get; set; } = "main";
}
