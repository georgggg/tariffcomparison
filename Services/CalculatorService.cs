using tariffcomparison.Models;
using tariffcomparison.Services.CalculationRules;

namespace tariffcomparison.Services;

public interface ICalculatorService
{
    IList<ServiceCost> Calculate(IList<TariffInfo> data, float consumption);
}
/// <summary>
/// Main service used for calculating the annual cost of every tariff/product
/// The calculation function is based on an evaluation engine approach. In this way new custom rules can be applied
/// to new products using the same engine 
/// </summary>
public class CalculatorService : ICalculatorService
{
    private Dictionary<TariffType, List<ICalculationRule>> _rules = new Dictionary<TariffType, List<ICalculationRule>>();
    
    public CalculatorService()
    {
        // Loading rules of calculation for each independent tariff type
        this._rules .Add(TariffType.KWhNotIncluded, new List<ICalculationRule>(){ 
                                                                                    new AddBaseCost(),
                                                                                    new AddConsumptionCost()
        });
        this._rules .Add(TariffType.KWhIncluded, new List<ICalculationRule>(){ 
                                                                                    new AddBaseCost(),
                                                                                    new AddExcessCost()
        });
    }

/// <summary>
/// Calculates the total annual cost of every product based on the consumption of KWh of the user
/// </summary>
/// <param name="data">Information sent by the electricity service provider</param>
/// <param name="consumption">Amount of KWh provided by the user</param>
/// <returns>A list of Products with their total annual cost</returns>
    public IList<ServiceCost> Calculate(IList<TariffInfo> data, float consumption)
    {
        IList<ServiceCost> result = new List<ServiceCost> ();
        
        // Calculate all the costs by evaluating every calculation rule for every tariff type and update the final cost
        foreach (TariffInfo info in data)
        {
            string productName = info.Name;
            float productCost = this.EvaluateRules(info, this._rules[(TariffType)info.Type], consumption);
            result.Add( new ServiceCost(){Name=productName, Cost=productCost} );
        }
        
        return result;
    }

    /// <summary>
    /// Evaluates all the rules passed with every product
    /// </summary>
    /// <param name="info">Tariff information of the product</param>
    /// <param name="rules">List of rules to evaluate</param>
    /// <param name="consumption">Amount of KWh provided by the user</param>
    /// <returns>The total annual cost for the current product</returns>
    private float EvaluateRules(TariffInfo info, List<ICalculationRule> rules, float consumption)
    {
        float total = 0;
        foreach (ICalculationRule rule in rules)
        {
            total+=rule.Calculate(info, consumption);
        }
        return total;
    }
}