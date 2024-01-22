using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Pets.Queries.GetPets
{
    public class PetCategoryDto : IMapFrom<PetCategory>
    {
        public decimal Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
