using Domain.ValueObjects;

namespace Application.Dtos;

public class AssetDto : EntityDto
{
    public Money Value { get; set; } = new Money(0,"USD");
    public string Name { get; set; } = string.Empty;
    public DateTime DateAcquired { get; set; } = DateTime.Now;
    public Money MonthlyIncome { get; set; } = new Money(0,"USD");
    public string Category { get; set; } = string.Empty;
}
