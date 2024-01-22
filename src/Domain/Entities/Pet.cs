namespace Domain.Entities;
public class Pet : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public PetCategory? Category { get; set; }
}
