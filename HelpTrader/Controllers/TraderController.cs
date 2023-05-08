using System.Net.Mime;
using HelpTrader.Models;
using HelpTrader.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpTrader.Controllers;

[Route("api/[controller]")]
public class TraderController : ControllerBase
{
    private readonly IBrokerDataService _service;

    public TraderController(IBrokerDataService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("all")]
    [Consumes(MediaTypeNames.Application.Json)]
 
    public BrokerData GetAbc()
    {
        return _service.AnalysisShare();
    }
}