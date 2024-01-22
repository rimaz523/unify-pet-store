using Application.Common;
using Application.Common.Interfaces.ApiServices;
using AutoMapper;
using MediatR;

namespace Application.Pets.Queries.GetPets;
public class GetAvailablePetsQuery : IRequest<List<PetDto>> {}

public class GetAvailablePetsQueryHandler : IRequestHandler<GetAvailablePetsQuery, List<PetDto>>
{
    private readonly IMapper _mapper;
    private readonly IPetStoreApiService _petStoreApiService;

    public GetAvailablePetsQueryHandler(IMapper mapper, IPetStoreApiService petStoreApiService)
    {
        _mapper = mapper;
        _petStoreApiService = petStoreApiService;
    }

    public async Task<List<PetDto>> Handle(GetAvailablePetsQuery request, CancellationToken cancellationToken)
    {
        var pets = await _petStoreApiService.GetPetsByStatus(Constants.Pets.Status.Available);
        return _mapper.Map<List<PetDto>>(pets.OrderBy(x => x.Category?.Name).ThenByDescending(x => x.Name));
    }
}
