using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Pages;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using FluentAssertions;
using WireMock.Server;
using Xunit;

namespace CloudFlare.Client.Test.Pages;

public class PagesUnitTests
{
    private readonly WireMockServer _wireMockServer;
    private readonly ConnectionInfo _connectionInfo;
    private const string TEST_PROJECT_NAME = "testcreateprojectfromapi";

    public PagesUnitTests()
    {
        _wireMockServer = WireMockServer.Start();
        _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
    }

    [Fact]
    public async Task TestCreatePagesProjectAsync()
    {
        using var client = new CloudFlareClient(WireMockConnection.EmailAddress, WireMockConnection.Key);
        var accounts = await client.Accounts.GetAsync();
        var account = accounts.Result[0];
        var newPageProject = new NewPagesProject
        {
            Account = account,
            Name = TEST_PROJECT_NAME
        };
        var createProject = await client.Pages.AddProjectAsync(newPageProject);
        createProject.Success.Should().BeTrue();
    }

    [Fact]
    public async Task TestGetPagesProjectsAsync()
    {
        var displayOptions = new DisplayOptions { Page = 1, PerPage = 10 };
        using var client = new CloudFlareClient(WireMockConnection.EmailAddress, WireMockConnection.Key);
        var accounts = await client.Accounts.GetAsync();
        var account = accounts.Result[0];
        var accountId = account.Id;
        var pageProjects = await client.Pages.GetProjectAsync(accountId, displayOptions);
        pageProjects.Success.Should().BeTrue();
    }

    [Fact]
    public async Task TestGetDetailPagesProjecAsync()
    {
        using var client = new CloudFlareClient(WireMockConnection.EmailAddress, WireMockConnection.Key);
        var accounts = await client.Accounts.GetAsync();
        var account = accounts.Result[0];
        var accountId = account.Id;
        var projectName = TEST_PROJECT_NAME;
        var pagesProject = await client.Pages.GetProjectDetailsAsync(accountId, projectName);
        pagesProject.Success.Should().BeTrue();
    }

    [Fact]
    public async Task TestGetDomainForProjectAsync()
    {
        using var client = new CloudFlareClient(WireMockConnection.EmailAddress, WireMockConnection.Key);
        var accounts = await client.Accounts.GetAsync();
        var account = accounts.Result[0];
        var accountId = account.Id;
        var projectName = "happynailsallenparkmi";
        var pagesDomain = await client.Pages.GetDomainsForProjectAsync(accountId, projectName);
        pagesDomain.Success.Should().BeTrue();
    }
}