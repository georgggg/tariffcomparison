using tariffcomparison.Models;

namespace tariffcomparison.Services.CalculationRules;

public class AddExcessCost : ICalculationRule
{
    /// <summary>
    /// Calculates the cost associated with the excess (difference between allowance in the tariff and the value provided by the user) of consumption in EUR.
    /// Case 1: If the product includes an amount of KWh covered by base cost, only the excess of KWh will be considered in the calculation
    /// Case 2: If the product does not include any KWh covered by base cost, then the whole amount of KWh (consumption) will be considered in the calculation
    /// Note: this considers the value of 'AdditionalKWCost' is provided in cents by the service provider
    /// </summary>
    /// <param name="tariffInfo">Product information from the service prodiver</param>
    /// <param name="consumption">Amount of KwH provided by the user</param>
    /// <returns>Excess cost</returns>
    public float  Calculate(TariffInfo tariffInfo, float consumption)
    {
        /// Note: this considers the value of 'AdditionalKWCost' is provided in cents by the service provider
        /// hence it needs to be converted to EUR for the calculation
        float costPerKWh = tariffInfo.AdditionalKWCost/100;
        
        if(tariffInfo.IncludedKW != null && tariffInfo.IncludedKW > 0 && consumption > tariffInfo.IncludedKW)
        {
            return (consumption - (float)tariffInfo.IncludedKW)*costPerKWh;
        }
        else
        {
            return 0;
        }
    }
}