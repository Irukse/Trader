using System.Net.Mime;
using bgTeam;
using Google.Protobuf.Collections;
using HelpTrader.Domain.Dto;
using HelpTrader.Services.Application.Manager.Repository;
using HelpTrader.Services.Story;
using HelpTrader.Services.Story.ShareService;
using Microsoft.AspNetCore.Mvc;

namespace HelpTrader.WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ShareController : ControllerBase
{
    private readonly IStoryBuilder _storyBuilder;
    private readonly IRedisRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShareController"/> class.
    /// </summary>
    /// <param name="storyBuilder"></param>
    /// <param name="repository"></param>
    public ShareController(IStoryBuilder storyBuilder, IRedisRepository repository)
    {
        _storyBuilder = storyBuilder;
        _repository = repository;
    }

    [HttpGet("PriceInformation")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<List<SharePrice>> GetListPriseInformation([FromQuery] RepeatedField<string> figi)
    {
        var context = new SharePriceInformationStoryContext()
        {
             Figi = figi
        };
        return await _storyBuilder.ReturnAsync<SharePriceInformationStoryContext, List<SharePrice>>(context);
    }
    
    [HttpGet("TechnicalAnalysisInformation")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<TechnicalAnalysisResponse> GetTechnicalAnalysisInformation([FromQuery] TechnicalAnalysisStoryContext context)
    {
        return await _storyBuilder.ReturnAsync<TechnicalAnalysisStoryContext, TechnicalAnalysisResponse>(context);
    }
}