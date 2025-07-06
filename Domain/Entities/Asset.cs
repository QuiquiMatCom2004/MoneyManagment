using Domain.Abstractions;

namespace Domain.Entities
{
    public class Asset : Entity, IAsset
    {
        decimal Value { get; set; } = 0;
        string Category { get; set; } = string.Empty;
    }
}
