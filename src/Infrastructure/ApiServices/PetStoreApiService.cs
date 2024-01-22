using System.Net.Http.Json;
using Application.Common.Interfaces.ApiServices;
using Domain.Entities;
using Infrastructure.Common;
using Microsoft.Extensions.Options;

namespace Infrastructure.ApiServices;
public class PetStoreApiService : IPetStoreApiService
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<IntegrationOptions> _options;

    public PetStoreApiService(HttpClient httpClient, IOptions<IntegrationOptions> options)
    {
        _httpClient = httpClient;
        _options = options;
        _httpClient.BaseAddress = new Uri(_options.Value.PetStoreApiDomain);
    }
    public async Task<IList<Pet>> GetPetsByStatus(string status)
    {
        return await _httpClient.GetFromJsonAsync<IList<Pet>>($"{_options.Value.PetStoreApiVersion + _options.Value.PetsByStatusEndpoint}?status={status}");
    }
}
