using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using Accounts.API.IntegrationTests.Models;
using NUnit.Framework;

namespace Accounts.API.IntegrationTests;

[TestFixture]
public class AccountsTests(WebApplicationFactory<Program> factory)
{
    public AccountsTests(): this(new WebApplicationFactory<Program>())
    {
    }
    
    [TestCase("accounts/all?isActiveOnly=true")]
    public async Task Accounts_Service_Returns_All_Active_Accounts_Correctly(string url)
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299

        var accounts = await JsonSerializer
            .DeserializeAsync<IEnumerable<AccountTestDto>>(await response.Content.ReadAsStreamAsync());

        accounts = accounts?.ToArray() ?? Array.Empty<AccountTestDto>();

        Assert.That(accounts, Is.Not.Empty);
        Assert.That(accounts.All(a => a.IsActive), Is.True);
    }
}