using System.Numerics;

namespace Domain.Entities;
public class Pet
{
    public decimal Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
