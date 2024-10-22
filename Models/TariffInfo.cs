namespace tariffcomparison.Models;

/// <summary>
/// Model class used to store the tariff information provided by the electricity providers 
/// </summary>
public class TariffInfo
{
    public string Name { get; set; }
    public int Type { get; set; }   
    public float BaseCost { get; set; }
    public float AdditionalKWCost { get; set; }
    public int? IncludedKW { get; set; }
}