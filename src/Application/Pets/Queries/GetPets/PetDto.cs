using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Pets.Queries.GetPets;
public class PetDto : IMapFrom<Pet>
{
    public decimal Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public PetCategoryDto? Category { get; set; }
}
