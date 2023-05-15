using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SimulatorBroker.Models;
using SimulatorBroker.Service;

namespace SimulatorBroker.Controllers;

public class BrokerController : ControllerBase
{
    private readonly IBrokerService _service;

    public BrokerController(IBrokerService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("BrokerData")]
    [Consumes(MediaTypeNames.Application.Json)]

    public BrokerData GetIBrokerService()
    {
        return _service.GetBrokerData();
    }
    
    [HttpGet]
    [Route("BrokerData/share/{share}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public BrokerData GetBrokerService([FromRoute]string share)
    {
        return _service.GetBrokerData(share);
    }
}