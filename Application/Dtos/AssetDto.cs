namespace Application.Dtos;

public class AssetDto
{
    public Guid Id { get; set; } = Guid.Empty;
    public decimal Value { get; set; } = 0;
    public string Category { get; set; } = string.Empty;
}
