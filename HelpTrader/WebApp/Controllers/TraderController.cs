using System.Net.Mime;
using bgTeam;
using HelpTrader.Models;
using HelpTrader.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpTrader.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TraderController : ControllerBase
{
    private readonly IBrokerDataService _service;

        public TraderController(IBrokerDataService service, IStoryBuilder serviceghh)
        {
            _service = service;
        }

    [HttpGet]
    [Route("all")]
    [Consumes(MediaTypeNames.Application.Json)]
 
    public async Task<BrokerData> GetAbc()
    {
        return await _service.AnalysisShare();
    }

    [HttpGet]
    [Route("all/share/{share}")]
    [Consumes(MediaTypeNames.Application.Json)]
 
    public async Task<BrokerData> GetDataForShare([FromRoute] string share)
    {
        return await _service.AnalysisForShare(share);
    }
    
    [HttpGet("[action]")]
  //  [Route("all/share/list/")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<List<BrokerData>> GetListDataForShare(List<string> shared)
    {
        return null;
        //await _service.GetListShareAsync(shared);
    }
    
    [HttpGet("[action]")]
  //  [Route("all/share/list/datafigi")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<List<ShareData>> GetListDataFigi(List<string> shared)
    {
        return await _service.GetListDataFigiShareAsync(shared);
    }
    
    // [HttpGet("[action]")]
    // [Route("all/share/price/{figi}")]
    // [Consumes(MediaTypeNames.Application.Json)]
    // public async Task<SharePrice> GetPriceData(string figi)
    // {
    //     return await _service.GetPriceShareAsync(figi);
    // }
    
    [HttpGet("[action]")]
   // [Route("all/share/price/{figi}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<List<SharePrice>> GetPriceData(List<string> figi)
    {
        return await _service.GetPriceShareListAsync(figi);
    }
    
    [HttpGet("[action]")]
   // [Route("all/share/price/analysis/{share}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<List<DataAnalysisShare>> GetAnalysisPriceData(List<string> share)
    {
        return await _service.GetAnalysisShareAsync(share);
    }
    
    // [HttpGet("{share}")]
    // [Route("all/share/price/analysis/")]
    // [Consumes(MediaTypeNames.Application.Json)]
    // public async Task<List<DataAnalysisShare>> GetAnalysisPriceData(List<string> share)
    // {
    //     return await _service.GetAnalysisShareAsync(share);
    // }

}