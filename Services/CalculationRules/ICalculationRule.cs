using tariffcomparison.Models;

namespace tariffcomparison.Services.CalculationRules;

public interface ICalculationRule
{
    float Calculate(TariffInfo tariffInfo, float consum);
}