using System.Net.Mime;
using bgTeam;
using HelpTrader.Services.Application.Manager.Repository;
using HelpTrader.Services.Story;
using HelpTrader.Services.Story.ShareService;
using Microsoft.AspNetCore.Mvc;

namespace HelpTrader.WebApp.Controllers;

//[ApiController]
//[Route("[controller]")]
[ApiController]
[Route("[controller]")]
public class ShareController : ControllerBase
{
    private readonly IStoryBuilder _storyBuilder;
    private readonly IRedisRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlacklistedEmailsController"/> class.
    /// </summary>
    /// <param name="languageService"></param>
    /// <param name="storyBuilder"></param>
    /// <param name="queryBuilder"></param>
    public ShareController(IStoryBuilder storyBuilder, IRedisRepository repository)
    {
        _storyBuilder = storyBuilder;
        _repository = repository;
    }

    // [HttpGet("[action]")]
    //
    //  [Consumes(MediaTypeNames.Application.Json)]
    // [HttpGet("[action]")]
    // [Consumes(MediaTypeNames.Application.Json)]
    // public async Task<ShareFigiInformationResponse> GetListFigiInformation(List<string> shares)
    // {
    //     var context = new ShareFigiInformationStoryContext()
    //     {
    //         Shares = shares
    //     };
    //    // return await _storyBuilder.Build(context).ReturnAsync<ShareFigiInformationResponse>();
    //     return await _storyBuilder.ReturnAsync<ShareFigiInformationStoryContext, ShareFigiInformationResponse>(context);
    // }


    [HttpGet("FigiInformation")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ShareFigiInformationResponse> GetListFigiInformation([FromQuery] List<string> shares)
    {
        var context = new ShareFigiInformationStoryContext()
        {
            Shares = shares
        };
        return await _storyBuilder.ReturnAsync<ShareFigiInformationStoryContext, ShareFigiInformationResponse>(context);
    }
    
    [HttpGet("PriseInformation")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<SharePriceInformationResponse> GetListPriseInformation([FromQuery] List<string> figi)
    {
        var context = new SharePriceInformationStoryContext()
        {
            Figi = figi
        };
        return await _storyBuilder.ReturnAsync<SharePriceInformationStoryContext, SharePriceInformationResponse>(context);
    }
    
    [HttpGet("AnalysisFair")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ShareAnalysisFairPriseResponse> GetListAnalysisFairInformation([FromQuery] List<string> share)
    {
        var context = new ShareAnalysisFairPriseStoryContext()
        {
           Share = share
        };
        return await _storyBuilder.ReturnAsync<ShareAnalysisFairPriseStoryContext, ShareAnalysisFairPriseResponse>(context);
    }
}



