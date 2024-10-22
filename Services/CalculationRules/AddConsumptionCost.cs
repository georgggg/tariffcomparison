using tariffcomparison.Models;

namespace tariffcomparison.Services.CalculationRules;

public class AddConsumptionCost : ICalculationRule
{
    /// <summary>
    /// Calculates the cost associated with normal the consumption in EUR
    /// Note: this considers the value of 'AdditionalKWhCost' is provided in cents by the service provider
    /// </summary>
    /// <param name="tariffInfo">Product information from the service prodiver</param>
    /// <param name="consum">Amount of KwH provided by the user</param>
    /// <returns>Excess cost</returns>
    public float Calculate(TariffInfo tariffInfo, float consum)
    {
        /// Note: this considers the value of 'AdditionalKWCost' is provided in cents by the service provider
        /// hence it needs to be converted to EUR for the calculation
        float costPerKWh = tariffInfo.AdditionalKWCost/100;
        return consum*costPerKWh;
    }
}