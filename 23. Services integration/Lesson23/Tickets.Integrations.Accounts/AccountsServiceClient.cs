using System.Text.Json;
using Tickets.Application.Models;

namespace Tickets.Integrations.Accounts;

public sealed class AccountsServiceClient(IHttpClientFactory httpClientFactory) : IAccountsServiceClient
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("accounts");
    
    public async Task<AccountInfoDto?> GetAccountInfo(Guid id)
    {
        using var response = await _client.GetAsync($"accounts/{id}");
        using var content = response.Content;

        return await JsonSerializer.DeserializeAsync<AccountInfoDto>(await content.ReadAsStreamAsync());
    }
}