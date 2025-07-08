public enum AssetCategorys
{
    RawMaterial,
    RealEstate,
    Investment,
    CriptoCurrency,
    Actions,
    Other
}
public enum LiabilityCategorys
{
    CreditCard,
    Loan,
    FixedExpenses,
    Other
}
public static class CategorysExtensions
{
    public static AssetCategorys ToAssetCategory(this string category)
    {
        return category switch
        {
            "RawMaterials" => AssetCategorys.RawMaterial,
            "Actions" => AssetCategorys.Actions,
            "Cryptocurrencies" => AssetCategorys.CriptoCurrency,
            "Investments" => AssetCategorys.Investment,
            "RealEstate" => AssetCategorys.RealEstate,
            _ => throw new ArgumentException("Invalid category")
        };
    }
    public static string AssetToString(this AssetCategorys category)
    {
        return category switch
        {
            AssetCategorys.RawMaterial => "RawMaterials",
            AssetCategorys.Actions => "Actions",
            AssetCategorys.CriptoCurrency => "Cryptocurrencies",
            AssetCategorys.Investment => "Investments",
            AssetCategorys.RealEstate => "RealEstate",
            _ => "Other"
        };
    }
    public static LiabilityCategorys ToLiabilityCategory(this string category)
    {
        return category switch
        {
            "CreditCard" => LiabilityCategorys.CreditCard,
            "Loan" => LiabilityCategorys.Loan,
            "FixedExpenses" => LiabilityCategorys.FixedExpenses,
            _ => throw new ArgumentException("Invalid category")
        };
    }
    public static string LiabilityToString(this LiabilityCategorys category)
    {
        return category switch
        {
            LiabilityCategorys.CreditCard => "CreditCard",
            LiabilityCategorys.Loan => "Loan",
            LiabilityCategorys.FixedExpenses => "FixedExpenses",
            _ => "Other"
        };
    }
}