using Application.Dtos;

namespace Application.Features.Create.Assets
{
    public record AssetCommand : ICommand<AssetDto>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; } = 0;
        public string Currency { get; set; } = string.Empty;
        public DateTime DateAcquired { get; set; } = DateTime.Now;
        public string Category { get; set; } = string.Empty;
        //RawMaterials
        public decimal? SellPrice { get; set; } = null;
        //Actions
        public decimal? DividendYield {  get; set; } = null;
        //Cryptocurrencies
        public decimal? MarketCap { get; set; } = null;
        //Investments
        public decimal? PorcentageInvestment { get; set; } = null;
        public decimal? AnualPerformace { get; set; } = null;
        //RealEstate
        public decimal? RentPrice { get; set; } = null;
        public decimal? ChoreExpenses { get; set; } = null;
    }
}
