namespace tariffcomparison.Models;

/// <summary>
/// Enum that list the two currently available types of tarrifs
/// 1: The current product does not include any KWh in the base cost
/// 2: The current product does include some KWh in the base cost
/// </summary>
public enum TariffType
{
    None = 0,
    KWhNotIncluded = 1,
    KWhIncluded = 2,
}