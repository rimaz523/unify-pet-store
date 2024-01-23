using Application.Common;
using Application.Common.Interfaces.ApiServices;
using Application.Pets.Queries.GetPets;
using AutoMapper;
using Domain.Entities;

namespace ApplicationUnitTests.Pets.Queries.GetPets
{
    public class GetAvailablePetsQueryHandlerTests
    {
        private readonly GetAvailablePetsQueryHandler _handler;
        private readonly Mock<IPetStoreApiService> _mockPetStoreApiService;
        private readonly IMapper _mapper;

        public GetAvailablePetsQueryHandlerTests()
        {
            _mockPetStoreApiService = new Mock<IPetStoreApiService>();
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pet, PetDto>();
                cfg.CreateMap<PetCategory, PetCategoryDto>();
            });
            _mapper = mapperConfiguration.CreateMapper();
            _handler = new GetAvailablePetsQueryHandler(_mapper, _mockPetStoreApiService.Object);
        }

        [Fact]
        public async Task Handle_WhenAvailablePetsExists_ReturnsPetsDto_OrderedByCategoryAsc_ThenOrdererdByNameDesc()
        {
            // Arrange
            var query = new GetAvailablePetsQuery();
            var cancellationToken = new CancellationToken();

            var availablePets = new List<Pet>
            {
                new Pet
                {
                    Id = 201,
                    Name = "Simba",
                    Status = "available",
                    Category = new PetCategory { Id = 1, Name = "Himalayan" }
                },
                new Pet
                {
                    Id = 202,
                    Name = "Nala",
                    Status = "available",
                    Category = new PetCategory { Id = 1, Name = "Himalayan" }
                },
                new Pet
                {
                    Id = 203,
                    Name = "Ted",
                    Status = "available",
                    Category = new PetCategory { Id = 2, Name = "Burmese" }
                }
            };

            var expectedPetsInOrder = new List<PetDto>
            {
                new PetDto
                {
                    Id = 203,
                    Name = "Ted",
                    Status = "available",
                    Category = new PetCategoryDto { Id = 2, Name = "Burmese" }
                },
                new PetDto
                {
                    Id = 201,
                    Name = "Simba",
                    Status = "available",
                    Category = new PetCategoryDto { Id = 1, Name = "Himalayan" }
                },
                new PetDto
                {
                    Id = 202,
                    Name = "Nala",
                    Status = "available",
                    Category = new PetCategoryDto { Id = 1, Name = "Himalayan" }
                }
            };

            _mockPetStoreApiService.Setup(x => x.GetPetsByStatus(Constants.Pets.Status.Available))
                .ReturnsAsync(availablePets);

            // Act
            var result = await _handler.Handle(query, cancellationToken);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equivalent(expectedPetsInOrder.First(), result.First(), true);
            Assert.Equivalent(expectedPetsInOrder[1], result[1], true);
            Assert.Equivalent(expectedPetsInOrder[2], result[2], true);
        }

        [Fact]
        public async Task Handle_WhenNoAvailablePetsExists_ReturnsEmptyList()
        {
            // Arrange
            var query = new GetAvailablePetsQuery();
            var cancellationToken = new CancellationToken();

            var availablePets = new List<Pet>();
            var expectedPetsInOrder = new List<PetDto>();

            _mockPetStoreApiService.Setup(x => x.GetPetsByStatus(Constants.Pets.Status.Available))
                .ReturnsAsync(availablePets);

            // Act
            var result = await _handler.Handle(query, cancellationToken);

            // Assert
            Assert.Empty(result);
        }
    }
}
