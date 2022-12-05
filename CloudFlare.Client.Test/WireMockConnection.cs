using System;
using CloudFlare.Client.Api.Authentication;
using CloudFlare.Client.Contexts;

namespace CloudFlare.Client.Test
{
    public class WireMockConnection
    {
        public static string EmailAddress { get; } = "";

        public static string Key { get; } = "";

        public static string Token { get; } = "";

        public static ApiKeyAuthentication ApiKeyAuthentication { get; } = new(EmailAddress, Key);

        public static ApiTokenAuthentication ApiTokenAuthentication { get; } = new(Token);

        public ConnectionInfo ConnectionInfo { get; }

        public WireMockConnection(string address)
        {
            ConnectionInfo = new ConnectionInfo
            {
                Address = new Uri(address)
            };
        }
    }
}