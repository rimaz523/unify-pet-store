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
        return _mapper.Map<List<PetDto>>(await _petStoreApiService.GetPetsByStatus(Constants.Pets.Status.Available));
    }
}
