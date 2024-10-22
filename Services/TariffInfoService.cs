using tariffcomparison.Models;

public interface ITariffInfoService
{
    IList<TariffInfo> GetTariffs();
}

/// <summary>
/// Service used to simulate a call to get tariff information from different electricity providers 
/// </summary>
public class TariffInfoService : ITariffInfoService
{
    /// <summary>
    /// Returns two records of testing data
    /// </summary>
    /// <returns>Demo data</returns>
    public IList<TariffInfo> GetTariffs()
    {
        List<TariffInfo> tariffInfo = new List<TariffInfo>();
        tariffInfo.Add(new TariffInfo {Name="Product A", Type=1, BaseCost=5, AdditionalKWCost=22});
        tariffInfo.Add(new TariffInfo {Name="Product B", Type=2, BaseCost=800, AdditionalKWCost=30, IncludedKW=4000});
        return tariffInfo;
    }
}