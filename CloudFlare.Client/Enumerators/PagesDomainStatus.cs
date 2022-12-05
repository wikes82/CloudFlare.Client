using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Status of CF Pages domain
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PagesDomainStatus
    {
        /// <summary>
        /// Active
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// Pending
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending
    }
}
