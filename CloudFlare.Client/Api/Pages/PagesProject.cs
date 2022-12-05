using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Pages;

/// <summary>
/// Pages project
/// </summary>
public class PagesProject
{
    /// <summary>
    /// The cf page project name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Page ID
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Sub domain
    /// </summary>
    [JsonProperty("subdomain")]
    public string SubDomain { get; set; }

    /// <summary>
    /// Domains
    /// </summary>
    [JsonProperty("domains")]
    public IReadOnlyList<string> Domains { get; set; }

    /// <summary>
    /// Created timestamp
    /// </summary>
    [JsonProperty("created_on")]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// production branch of the project. Used to identify production deployments
    /// </summary>
    [JsonProperty("production_branch")]
    public string ProductionBranch { get; set; }

    /// <summary>
    /// Production Script Name
    /// </summary>
    [JsonProperty("production_script_name")]
    public string ProductionScriptName { get; set; }

    /// <summary>
    /// Preview Script Name
    /// </summary>
    [JsonProperty("preview_script_name")]
    public string PreviewScriptName { get; set; }
}
