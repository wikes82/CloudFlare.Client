using System;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Pages;

/// <summary>
/// Pages Domain
/// </summary>
public class PagesDomain
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Domain ID
    /// </summary>
    [JsonProperty("domain_id")]
    public string DomainId { get; set; }

    /// <summary>
    /// Domain name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Domain Status
    /// </summary>
    [JsonProperty("status")]
    public PagesDomainStatus Status { get; set; }

    /// <summary>
    /// Created timestamp
    /// </summary>
    [JsonProperty("created_on")]
    public DateTime CreatedDate { get; set; }
}
