using tariffcomparison.Models;

namespace tariffcomparison.Services.CalculationRules;

public class AddBaseCost : ICalculationRule
{
    /// <summary>
    /// Returns the base cost of the product as provided in the tariff information
    /// NOTE: It is assumed that if the tariff of the product DOES NOT include any KWh in the base price then
    /// the base price in the information made available by the service provider is the cost per month,
    /// this means only in this case the base cost will be multiplied by 12 to reflect the annual base cost.
    /// For any other case (product) the base cost is considered to be the annual cost of that tariff
    /// </summary>
    /// <param name="tariffInfo">Product information from the service prodiver</param>
    /// <param name="consumption">Amount of KwH provided by the user</param>
    /// <returns>the base cost of the tariff for the current product in EUR</returns>
    public float  Calculate(TariffInfo tariffInfo, float consumption)
    {
        if(tariffInfo.Type == (int)TariffType.KWhNotIncluded)
        {
            return tariffInfo.BaseCost*12;    
        }
        else
        {
            return tariffInfo.BaseCost;
        }
    }
}