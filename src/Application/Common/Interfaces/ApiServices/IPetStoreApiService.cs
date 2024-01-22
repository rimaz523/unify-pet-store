using Domain.Entities;

namespace Application.Common.Interfaces.ApiServices;
public interface IPetStoreApiService
{
    public Task<IList<Pet>> GetPetsByStatus(string status);
}
