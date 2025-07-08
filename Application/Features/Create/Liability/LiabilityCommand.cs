namespace Application.Features.Create.Liability
{
    public record LiabilityCommand : ICommand<LiabilityDto>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public string Currency { get; set; } = string.Empty;
        public DateTime DueDate { get; set; } = DateTime.Now;
        public string Category { get; set; } = string.Empty;
        public decimal? InterestRate { get; set; } = null;
        //Credit Cards
        public decimal? MinimumPaymentPercentage { get; set; } = null;
        //Loans
        public int? MonthToPay { get; set; } = null;
        //FixedExpenses
        public decimal? Beneficts { get; set; } = null;
    }
}
