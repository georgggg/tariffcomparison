using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using tariffcomparison.Models;
using tariffcomparison.Services;

namespace tariffcomparison.Controllers;

[ApiController]
[Route("[controller]")]
public class CompareController : ControllerBase
{
    private float _consumption;
    private readonly ITariffInfoService _tariffInfoService;
    private readonly ICalculatorService _calculatorService;

    public CompareController(ITariffInfoService tariffInfoService, ICalculatorService calculatorService)
    {
        this._tariffInfoService = tariffInfoService;
        this._calculatorService = calculatorService;
    }

    [HttpGet("{consumption}")]

    public IActionResult Get(float consumption)
    {
        // Receive call with the user consumption in KwH as parameter and test if the format is correct
        if(consumption > 0)
        {
            this._consumption = consumption;
        }
        else
        {
            return BadRequest("Consumption value must be equal or greater than 1");
        }
        // Call the electricity providers service and get tariff information
        IList<TariffInfo> tariffs = _tariffInfoService.GetTariffs();
        
        // Calculate the anual costs and get comparison results
        IList<ServiceCost> costs = _calculatorService.Calculate(tariffs, consumption);
        
        // Order results in descending order and return
        costs = costs.OrderBy( x => x.Cost).ToList();
        return Ok(costs);
    }
}
